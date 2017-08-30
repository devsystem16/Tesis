using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using System.Collections;
 

namespace Assets.entidades
{
    class GestureCompleted
    {
        private string gesto;
        public GestureCompleted (string unGesto){
            this.gesto = unGesto; 
        }

        public string Gesto {
                get { return gesto; }
                set { gesto = value; }
        }


        public void executeGesture(string unGEsto, float x, float y) {

            switch (unGEsto) {

                case "Push":
                break;

                case "Click":
                     
                    break;





            }


        }



    }
}
