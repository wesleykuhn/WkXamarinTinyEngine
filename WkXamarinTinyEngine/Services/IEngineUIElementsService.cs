﻿using WkXamarinTinyEngine.Models;
using System.Collections.Generic;
using Xamarin.Forms;

namespace WkXamarinTinyEngine.Services
{
    public interface IEngineUIElementsService
    {
        Dictionary<View, EngineUIElementInfoModel> UIElementsInformation { get; set; }

        void PlaceAllElementsAtMainGridOfEnginePage(Grid mainGrid);
        void RegisterElement(View element, double width, double height, ulong originalUIMeshPointX, ulong originalUIMeshPointY);
    }
}