using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {
        //eger burda tek parametre gonderirsen sadece message calısır. ama cift paramaetre gonderilirse alttaki ctorda calısır bunu saglayan yontem :this(success) tir
        public Result(bool success, string message):this(success)
        {
            Message = message;
            //read only alanlar constructer da set edilebilir.
        }

        public Result(bool success)
        {
            Success = success;
        }

        public bool Success { get; }
        public string Message { get; }
    }
}
