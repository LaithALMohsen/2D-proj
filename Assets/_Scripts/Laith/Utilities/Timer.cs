using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Laith.Utilities
{
public class Timer 
{
        public event Action OnTimerDone;

        private float startTime;
        private float duration;//ãÏÉ ÇáãÄÞÊ
        private float targetTime;//ãÊÛíÑ ááÊÍÞÞ ãä ÇäÊåÇÁ ÇáæÞÊ ÇáãÍÏÏ
        private bool isActive; 
             
        public Timer(float duration)
        {

            this.duration = duration;
        }
        
             
        public void StartTimer()
        {

            startTime = Time.time;
            targetTime = startTime + duration;
            isActive = true;
        }

        public void StopTimer()
        {

            isActive = false;
        }

        public void Tick()
        {
            if (!isActive) return;
            

            if(Time.time >= targetTime)
            {

                OnTimerDone?.Invoke();
                StopTimer();
            }

        }
    
}



}

