using BepInEx;
using HarmonyLib;
using Meta.Voice.Audio;
using Photon.Voice;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

namespace ASTRA_CLIENT.Utilities
{
   
    [HarmonyPatch(typeof(GorillaSpeakerLoudness), "UpdateLoudness")]
    class SoundManager
    {
        public static async Task PalySoundOnMIC(AudioClip sound, bool looping)
        {
            if (GorillaTagger.Instance.myRecorder != null)
            {
                Play2dAudio(sound, 0.6f);
                GorillaTagger.Instance.myRecorder.SourceType = Photon.Voice.Unity.Recorder.InputSourceType.AudioClip;
                GorillaTagger.Instance.myRecorder.AudioClip = sound;
                GorillaTagger.Instance.myRecorder.LoopAudioClip = looping;
                GorillaTagger.Instance.myRecorder.RestartRecording(true);

                await Task.Delay((int)(sound.length * 1000));
                StopSoundThroughMicrophone1();
            }
        }

        public static void StopSoundThroughMicrophone1()
        {
            if (GorillaTagger.Instance.myRecorder != null)
            {
                GorillaTagger.Instance.myRecorder.SourceType = Photon.Voice.Unity.Recorder.InputSourceType.Microphone;
                GorillaTagger.Instance.myRecorder.AudioClip = null;
                GorillaTagger.Instance.myRecorder.RestartRecording(true);
            }
        }

        public static async Task<AudioClip?> LoadAudioFromFile(string filenames)
        {
            string filePath = Paths.PluginPath + "//CustomSounds//" + filenames;

            if (audioFilePool.ContainsKey(filenames))
            {
                return audioFilePool[filenames];
            }

            using (UnityWebRequest www = UnityWebRequestMultimedia.GetAudioClip("file:///" + filePath, GetAudioType(GetFileExtension(filenames))))
            {
                await www.SendWebRequest();

                if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
                {
                    Debug.Log(www.error);
                    return null;
                }

                AudioClip sound = DownloadHandlerAudioClip.GetContent(www);
                audioFilePool.Add(filenames, sound);
                return sound;
            }
        }






        public static async Task<AudioClip?> LoadSoundFromURl(string path, string URl)
        {
            string path1 = Paths.PluginPath + "//CustomSounds//" + path;
            WebClient webClient = new WebClient();
            _ = webClient.DownloadFileTaskAsync(URl, path1); 
            return await LoadAudioFromFile(path1);
        }




        public static string GetFileExtension(string fileName)
        {
            return fileName.ToLower().Split('.')[fileName.Split('.').Length - 1];
        }





        public static AudioType GetAudioType(string extension)
        {
            switch (extension.ToLower())
            {
                case "mp3":
                    return AudioType.MPEG;
                case "wav":
                    return AudioType.WAV;
                case "ogg":
                    return AudioType.OGGVORBIS;
                case "aiff":
                    return AudioType.AIFF;
                case "m4a":
                    return AudioType.MPEG;
                default:
                    return AudioType.UNKNOWN;

            }

        }


        public static GameObject? AudioMSG = null;
        public static Dictionary<string, AudioClip> audioFilePool = new Dictionary<string, AudioClip> { };

        public static void Play2dAudio(AudioClip clip, float volume = 100f)
        {
            if (AudioMSG != null)
            {
                GameObject.Destroy(AudioMSG);
            }
            AudioMSG = new GameObject("AudioMSG");
            AudioSource audioSource = AudioMSG.AddComponent<AudioSource>();
            audioSource.clip = clip;
            audioSource.volume = volume;
            audioSource.spatialBlend = 0f;
            audioSource.Play();
            GameObject.Destroy(AudioMSG, clip.length + 0.1f);
        }
    }
}
