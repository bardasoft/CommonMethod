using System;
using System.Collections.Generic;
using System.Text;

namespace PublicClassCurrency.Map
{
    public interface IMapControl
    {
        
        bool SetCenterPoint(MapPointInfo point);

        bool SetMapLevel(MapPointInfo point);

        bool SetMapPointInfo(MapPointInfo point);

        bool SetMapMarker(MapPointInfo point, string strMarkerPicFilePath);

    }
}
