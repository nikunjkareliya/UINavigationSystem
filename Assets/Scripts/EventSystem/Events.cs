using System;
using System.Collections.Generic;
using UnityEngine;

namespace Shared.EventSystem
{
    public static class Events
    {
        private static Dictionary<string, Delegate> eventDictionary = new Dictionary<string, Delegate>();

        public static void Register(string eventType, Action eventHandler)
        {
            if (eventDictionary.TryGetValue(eventType, out Delegate thisEvent))
            {
                eventDictionary[eventType] = (Action)thisEvent + eventHandler;
            }
            else
            {
                eventDictionary.Add(eventType, eventHandler);
            }
        }

        public static void Register<T>(string eventType, Action<T> eventHandler)
        {
            if (eventDictionary.TryGetValue(eventType, out Delegate thisEvent))
            {
                eventDictionary[eventType] = (Action<T>)thisEvent + eventHandler;
            }
            else
            {
                eventDictionary.Add(eventType, eventHandler);
            }
        }

        public static void Register<T1, T2>(string eventType, Action<T1, T2> eventHandler)
        {
            if (eventDictionary.TryGetValue(eventType, out Delegate thisEvent))
            {
                eventDictionary[eventType] = (Action<T1, T2>)thisEvent + eventHandler;
            }
            else
            {
                eventDictionary.Add(eventType, eventHandler);
            }
        }

        public static void Unregister(string eventType, Action eventHandler)
        {
            if (eventDictionary.TryGetValue(eventType, out Delegate thisEvent))
            {
                eventDictionary[eventType] = (Action)thisEvent - eventHandler;
            }
        }

        public static void Unregister<T>(string eventType, Action<T> eventHandler)
        {
            if (eventDictionary.TryGetValue(eventType, out Delegate thisEvent))
            {
                eventDictionary[eventType] = (Action<T>)thisEvent - eventHandler;
            }
        }

        public static void Unregister<T1, T2>(string eventType, Action<T1, T2> eventHandler)
        {
            if (eventDictionary.TryGetValue(eventType, out Delegate thisEvent))
            {
                eventDictionary[eventType] = (Action<T1, T2>)thisEvent - eventHandler;
            }
        }

        public static void Execute(string eventType)
        {
            if (eventDictionary.TryGetValue(eventType, out Delegate thisEvent))
            {
                (thisEvent as Action)?.Invoke();
            }
        }

        public static void Execute<T>(string eventType, T arg)
        {
            if (eventDictionary.TryGetValue(eventType, out Delegate thisEvent))
            {
                (thisEvent as Action<T>)?.Invoke(arg);
            }
        }

        public static void Execute<T1, T2>(string eventType, T1 arg1, T2 arg2)
        {
            if (eventDictionary.TryGetValue(eventType, out Delegate thisEvent))
            {
                (thisEvent as Action<T1, T2>)?.Invoke(arg1, arg2);
            }
        }
    }
}