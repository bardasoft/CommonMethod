using System;
using System.Collections.Generic;
using System.Text;

namespace PublicClassCurrency.Map
{
    public delegate void MapControlLoadEndDelegate(object sender, object MapControlLoadEndValue);
    public interface IMapControl
    {
        MapType mapType
        {
            get;
            set;
        }

        event MapControlLoadEndDelegate MapControlLoadEndEvent;
        bool SetCenterPoint(MapPointInfo point);

        bool SetMapLevel(MapPointInfo point);

        bool SetMapPointInfo(MapPointInfo point);

        bool SetMapMarker(MapPointInfo point, string strMarkerPicFilePath);

    }
}
