using Scripts.Model.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Scripts.Model.Definitions
{
    [CreateAssetMenu(menuName ="Defs/Dialog", fileName ="Dialog")]
    public class DialogDef : ScriptableObject
    {
        [SerializeField] private DialogData _data;

        public DialogData Data => _data;

    }
}
