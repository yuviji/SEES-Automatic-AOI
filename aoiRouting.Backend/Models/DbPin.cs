﻿using LinqToDB.Mapping;
using aoiRouting.Shared.Models;

namespace aoiRouting.Backend.Models
{
    [Table("pins")]
    [Column("id", nameof(ID))]
    [Column("user_id", nameof(UserID))]
    [Column("aoi_id", nameof(AOIID))]
	[Column("point_id", nameof(PointID))]
	[Column("lat", nameof(Lat))]
    [Column("lon", nameof(Lon))]
    [Column("collected", nameof(Collected))]
    [Column("created", nameof(Created))]
    [Column("notes", nameof(Notes))]
    public record DbPin : Pin { }
}