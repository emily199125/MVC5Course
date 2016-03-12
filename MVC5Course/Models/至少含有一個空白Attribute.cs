using System;
using System.ComponentModel.DataAnnotations;

namespace MVC5Course.Models
{
    public class 至少含有一個空白Attribute : DataTypeAttribute
    {
        public 至少含有一個空白Attribute():base(DataType.Text)
        {
        }

        public override bool IsValid(object value)
        {
            var str = (string)value;
            return str.Contains(" ");
        }


    }
}