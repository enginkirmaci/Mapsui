﻿using System.Collections.Generic;
using Mapsui.Geometries;
using Mapsui.Geometries.WellKnownText;
using Mapsui.GeometryLayers;
using Mapsui.Layers;
using Mapsui.Providers;
using Mapsui.Samples.Common;
using Mapsui.Styles;
using Mapsui.UI;
using Mapsui.Utilities;

#pragma warning disable IDISP001 // Dispose created

namespace Mapsui.Tests.Common.Maps
{
    public class ProjectionSample : ISample
    {
        public static readonly string WktOfAmsterdam = "MULTIPOLYGON(((4.95683945612161 52.324079432661, 4.96754190484495 52.3277579155152, 4.97025619144554 52.3261497160456, 4.97534866950582 52.3306434470746, 4.9844008756692 52.3305847287028, 4.99053906881772 52.3266328839288, 4.99717717355922 52.3174065611471, 4.99786791902704 52.3138946240045, 5.01609570372136 52.3245138001009, 5.01641520919658 52.3231396786747, 5.01766090609842 52.3232694038901, 5.02154290068345 52.3024928001643, 5.01177102387486 52.303387929296, 5.00385209171042 52.2984911549071, 5.00183357050942 52.2928941914856, 4.99748357072627 52.2891589888832, 4.98357755863888 52.2904155762499, 4.969809200596 52.2831685401466, 4.96768884068402 52.2795748928408, 4.96616561705579 52.281043482866, 4.96221704460842 52.2802024760158, 4.96118068470515 52.278248386163, 4.95540665969782 52.278317318603, 4.92927711815841 52.3084810216011, 4.93634635951356 52.3126605383955, 4.93523403689258 52.3138876211645, 4.93872685439856 52.3150873019502, 4.93800867964684 52.3164956594117, 4.93993788976303 52.3171590768557, 4.93958084485612 52.3191170624813, 4.94102782745413 52.3196168560032, 4.93760280602078 52.3232709021318, 4.94024896085198 52.3255997720806, 4.94766096637108 52.3281351234126, 4.95267293906881 52.3226531256159, 4.95683945612161 52.324079432661)),((4.75892671993255 52.3846797347732, 4.75768098728856 52.3968964817118, 4.72872416031007 52.4006936553853, 4.73919531414285 52.4312198223393, 4.76716887412622 52.4276036417226, 4.7675644251225 52.4287561349675, 4.85595924547104 52.4165307656936, 4.85989603701279 52.4204489888692, 4.85784888872128 52.4244573354481, 4.8626933066312 52.4300242420064, 4.8707472602639 52.4303292417682, 4.87787225709463 52.4257584177859, 4.89218109613398 52.425423597462, 4.90081311047285 52.4239044843875, 4.93068103891453 52.4115844658466, 4.94449510601506 52.4146657094181, 4.94763234082633 52.4214180849864, 4.9513766890753 52.4218543313868, 4.95161165535665 52.4233740969119, 4.95622608352304 52.4220428308295, 4.97331609932713 52.4227868057541, 4.98268880990471 52.4267197713162, 4.98704638895563 52.4228339622765, 4.98910026495288 52.4233082327779, 4.99038962625471 52.4254336213124, 5.00029877770584 52.4254214466417, 5.01783147943778 52.4191591360035, 5.0216512548764 52.421202167359, 5.02708580360069 52.419960548324, 5.03047206062088 52.4156567631843, 5.03663626283441 52.4186770018004, 5.04805370024972 52.4153758448027, 5.06494443392255 52.4170946628007, 5.0685518956855 52.4162326257032, 5.0671610978185 52.4134247636741, 5.05667486593654 52.4143216977506, 5.05147117360546 52.4124556333545, 5.04679735817182 52.4067172213664, 5.03874576890772 52.4046446494559, 5.03209156786855 52.400652381121, 5.02917760087573 52.3975878302809, 5.02505704785586 52.3876080524353, 5.01936804164935 52.3863502310693, 5.01724114374041 52.3842315158472, 5.01311820006255 52.3837062710873, 5.01165857659048 52.3739500671581, 5.00835242167786 52.3724745498059, 5.00135515012919 52.375031412423, 4.99947855977772 52.3780361444339, 4.9891616974314 52.3772020174302, 4.98324553950961 52.3737307250053, 4.97967776219503 52.3736645745189, 4.97326355449568 52.3796370944286, 4.96852144243451 52.3794586465493, 4.96360830900367 52.3833508043714, 4.96148232488184 52.3814288112163, 4.95955289816332 52.3819880820459, 4.96122012120958 52.3812031769912, 4.95875840052466 52.3806100989799, 4.96186526826133 52.3797854460483, 4.95991139420532 52.3798413260419, 4.98194327779275 52.3683965907762, 4.96330814245359 52.3686548996222, 4.96071504016995 52.3665244951848, 4.96162060602953 52.3639572758494, 4.96819226338112 52.361446188184, 4.97383263113991 52.3611244839301, 4.97798835537922 52.3641857446406, 4.98077230157409 52.363188713971, 4.98477331266844 52.3655751269865, 4.99017696753713 52.3638587491747, 4.9858304047549 52.3607073945739, 4.98748071164153 52.3600299141597, 4.99138456774339 52.3617956273437, 5.00836751498889 52.3535106227023, 5.01650255334431 52.3548575646531, 5.01685241208389 52.3498704964508, 5.009354490192 52.3444721600355, 5.01261536329627 52.3441140288926, 5.01137868194247 52.3428518307751, 5.00871673439225 52.3418187505048, 5.00426385185613 52.342586357905, 4.9991513542874 52.3415720712085, 4.97464114069465 52.3546921171792, 4.96946004301185 52.356210843758, 4.95035961158261 52.3386338182301, 4.9365347134345 52.3345734438831, 4.92848876275361 52.3365557859455, 4.92376119455582 52.3354408600947, 4.92255342768436 52.3330813306996, 4.91292717599664 52.3305085892931, 4.91388553848157 52.3245535301703, 4.91028804872455 52.3235324519964, 4.91070152165606 52.3219073283546, 4.91422368133479 52.3203485984367, 4.91254310987308 52.3184005046632, 4.89611588971571 52.3224498675751, 4.85677235199552 52.3215879537689, 4.85596387386353 52.3303204824356, 4.84390684433575 52.3301488933687, 4.83957672503919 52.3291492592593, 4.83945330956816 52.3272612454071, 4.818424473029 52.3255531985999, 4.81543122015093 52.3278935849259, 4.79777347047234 52.3352848202098, 4.79053995768513 52.3418456389976, 4.75569023141445 52.3561532003097, 4.7548950875654 52.3583869249308, 4.75860393824499 52.3722209467153, 4.75643991839894 52.3777638957706, 4.75923656350473 52.3793965626519, 4.75892671993255 52.3846797347732)))";

        public string Name => "Projection";
        public string Category => "Tests";

        public void Setup(IMapControl mapControl)
        {
            mapControl.Map = CreateMap();
        }

        public static Map CreateMap()
        {
            // For Projections to work three things need to be set:
            // 1) The CRS on the Map to know what to project to.
            // 2) The CRS on the DataSource to know what to project from.
            // 3) The projection to project from the DataSource CRS to the Map CRS.

            var geometryLayer = CreateAmsterdamLayer();
            var extent = geometryLayer.Extent?.Grow(geometryLayer.Extent.Width * 0.1);
            var map = new Map
            {
                CRS = "EPSG:3857", // The Map CRS needs to be set
                BackColor = Color.FromString("WhiteSmoke")
            };
            map.Layers.Add(geometryLayer);
            map.Layers.Add(CreateCenterOfAmsterdamLayer());
            map.Home = n => n.NavigateToFullEnvelope(ScaleMethod.Fit);
            return map;
        }

        public static MemoryLayer CreateCenterOfAmsterdamLayer() // Needs no projection
        {
            return new MemoryLayer("Center of Amsterdam")
            {
#pragma warning disable IDISP004 // Don't ignore created IDisposable
                DataSource = new MemoryProvider<IFeature>(new PointFeature(new MPoint(545465.50488704059, 6866697.0250906311))),
#pragma warning restore IDISP004 // Don't ignore created IDisposable
                Style = new SymbolStyle { Fill = new Brush { Color = Color.Black }, SymbolScale = 0.5 }
            };
        }

        public static MemoryLayer CreateAmsterdamLayer() // Needs projection
        {
            var features = new List<GeometryFeature>
            {
                new GeometryFeature {Geometry = GeometryFromWKT.Parse(WktOfAmsterdam)}
            };

            var memoryProvider = new MemoryProvider<GeometryFeature>(features)
            {
                CRS = "EPSG:4326" // The DataSource CRS needs to be set
            };

            var dataSource = new ProjectingProvider(memoryProvider)
            {
                CRS = "EPSG:3857"
            };

            return new MemoryLayer
            {
                DataSource = dataSource,
                Name = "WGS84 Geometries",
                Opacity = 0.5
            };
        }
    }
}