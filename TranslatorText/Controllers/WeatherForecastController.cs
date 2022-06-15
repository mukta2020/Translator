using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace TranslatorText.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        
       

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }


        [HttpGet]
        public async Task<SynMedDrugDtoTranslate> Get(string ConvertLanguageCode)
        {
            List<TranslateValue> body1 = new List<TranslateValue>();

            SynMedDrugDto model = WeatherForecast.data();
            Object[] body = new Object[] { new { Text = model.otc_flag }, new { Text = model.local_drug_id }, new { Text = model.drug_picture }, new { Text = model.primary_drug_name }, new { Text = model.concentration }, new { Text = model.pipette_size }, new { Text = model.lid_hole_size }, new { Text = model.lid_volcanic }, new { Text = model.toggle_flag }, new { Text = model.fragile_flag }, new { Text = model.dispensing_height }, new { Text = model.mass_index }, new { Text = model.mass_index_concat }, new { Text = model.camera_set }, new { Text = model.length }, new { Text = model.added_timestamp }, new { Text = model.filename }, new { Text = model.LastUpdated }, new { Text = model.NationalDrugCode }, new { Text = model.FDBID }, new { Text = model.LabelName }, new { Text = model.DrugName }, new { Text = model.GenericNameIndicator }, new { Text = model.GenericSequenceNumber }, new { Text = model.Strength }, new { Text = model.PackageSize }, new { Text = model.Manufacturer }, new { Text = model.Schedule }, new { Text = model.StrengthUnitOfMeasure }, new { Text = model.RouteOfAdminAbbr }, new { Text = model.RouteOfAdministration }, new { Text = model.OTC }, new { Text = model.Storageconditions }, new { Text = model.NIOSH }, new { Text = model.Packaging }, new { Text = model.UnitDoseIndicator }, new { Text = model.UnitOfUseIndicator }, new { Text = model.TallManName }, new { Text = model.DosageForm }, new { Text = model.Active }, new { Text = model.UPC }, new { Text = model.Barcode }, new { Text = model.PDDBPieceWeight }, new { Text = model.PDDBPieceThickness }, new { Text = model.PDDBPieceLength }, new { Text = model.PDDBPieceWidth }, new { Text = model.PDDBPieceDiagonal }, new { Text = model.ThirtyDramCapacity }, new { Text = model._13dram }, new { Text = model.ImprintSide1 }, new { Text = model.ImprintSide2 }, new { Text = model.Clarity }, new { Text = model.Coating }, new { Text = model.Color }, new { Text = model.Flavor }, new { Text = model.Shape }, new { Text = model.NADAC }, new { Text = model.SWP }, new { Text = model.WAC }, new { Text = model.ATPCanisterNo }, new { Text = model.TCGDiameter }, new { Text = model.TCGLength }, new { Text = model.BeaconBottleHeight }, new { Text = model.BeaconBottleWidth }, new { Text = model.BeaconBottleDepth }, new { Text = model.MaxOrMiniCanisterHeightSetting }, new { Text = model.Color }, new { Text = model.MaxOrMiniCanisterWidthSetting }, new { Text = model.Color }, new { Text = model.MaxOrMiniCanisterPressureSetting }, new { Text = model.MaxOrMiniCanisterBaffleSetting }, new { Text = model.Color }, new { Text = model.PassRecipe }, new { Text = model.DivisionBlockID }, new { Text = model.BrushID }, new { Text = model.GuideBlockID }, new { Text = model.SlotLocationID }, new { Text = model.HandleID }, new { Text = model.BlockID }, new { Text = model.GelPadID } };


           // body1 = model.FDBPhonetic.Select(x => new object {  Text = x.PEMTXTE }).ToList();

         

            var requestBody = JsonConvert.SerializeObject(body);

            using (var client = new HttpClient())
            using (var request = new HttpRequestMessage())
            {
                request.Method = HttpMethod.Post;
                request.RequestUri = new Uri($"https://api.cognitive.microsofttranslator.com//translate?api-version=3.0&from=en&to={ConvertLanguageCode}");
                request.Content = new StringContent(requestBody, Encoding.UTF8, "application/json");
                request.Headers.Add("Ocp-Apim-Subscription-Key", "f4256d1dec854700877d450ba111d322");
                request.Headers.Add("Ocp-Apim-Subscription-Region", "eastus");

                var response = await client.SendAsync(request);
                var responseBody = await response.Content.ReadAsStringAsync();
                //var data = System.Reflection.Assembly.GetExecutingAssembly().CreateInstance(responseBody);


                // dynamic result = JsonConvert.SerializeObject(JsonConvert.DeserializeObject<Root>(responseBody), Formatting.Indented);
              //  dynamic datae = JsonConvert.SerializeObject(responseBody, Formatting.Indented);

                dynamic result = JsonConvert.DeserializeObject<dynamic>(responseBody);

                var hsdfg = result[0].translations[0].text.Value;

                var SynMedDrugDtoModel = new SynMedDrugDtoTranslate()
                {
                    otc_flag = Convert.ToString(result[0].translations[0].text.Value),
                    local_drug_id = Convert.ToString(result[1].translations[0].text.Value),
                    drug_picture = Convert.ToString(result[2].translations[0].text.Value),
                    primary_drug_name = Convert.ToString(result[3].translations[0].text.Value),
                    concentration = Convert.ToString(result[4].translations[0].text.Value),
                    pipette_size = Convert.ToString(result[5].translations[0].text.Value),
                    lid_hole_size = Convert.ToString(result[6].translations[0].text.Value),
                    lid_volcanic = Convert.ToString(result[7].translations[0].text.Value),
                    toggle_flag = Convert.ToString(result[8].translations[0].text.Value),
                    fragile_flag = Convert.ToString(result[9].translations[0].text.Value),
                    dispensing_height = Convert.ToString(result[10].translations[0].text.Value),
                    mass_index = Convert.ToString(result[11].translations[0].text.Value),
                    mass_index_concat = Convert.ToString(result[12].translations[0].text.Value),
                    camera_set = Convert.ToString(result[13].translations[0].text.Value),
                    length = Convert.ToString(result[14].translations[0].text.Value),
                    added_timestamp = Convert.ToString(result[15].translations[0].text.Value),
                    filename = Convert.ToString(result[16].translations[0].text.Value),
                    LastUpdated = Convert.ToString(result[17].translations[0].text.Value),
                    NationalDrugCode = Convert.ToString(result[18].translations[0].text.Value),
                    FDBID = Convert.ToString(result[19].translations[0].text.Value),
                    LabelName = Convert.ToString(result[20].translations[0].text.Value),
                    DrugName = Convert.ToString(result[21].translations[0].text.Value),
                    GenericNameIndicator = Convert.ToString(result[21].translations[0].text.Value),
                    GenericSequenceNumber = Convert.ToString(result[21].translations[0].text.Value),
                    Strength = Convert.ToString(result[21].translations[0].text.Value),
                    PackageSize = Convert.ToString(result[22].translations[0].text.Value),
                    Manufacturer = Convert.ToString(result[23].translations[0].text.Value),
                    Schedule = Convert.ToString(result[24].translations[0].text.Value),
                    StrengthUnitOfMeasure = Convert.ToString(result[25].translations[0].text.Value),
                    RouteOfAdminAbbr = Convert.ToString(result[26].translations[0].text.Value),
                    RouteOfAdministration = Convert.ToString(result[27].translations[0].text.Value),
                    OTC = Convert.ToString(result[28].translations[0].text.Value),
                    Storageconditions = Convert.ToString(result[29].translations[0].text.Value),
                    NIOSH = Convert.ToString(result[30].translations[0].text.Value),
                    Packaging = Convert.ToString(result[31].translations[0].text.Value),
                    UnitDoseIndicator = Convert.ToString(result[32].translations[0].text.Value),
                    UnitOfUseIndicator = Convert.ToString(result[33].translations[0].text.Value),
                    TallManName = Convert.ToString(result[34].translations[0].text.Value),
                    DosageForm = Convert.ToString(result[35].translations[0].text.Value),
                    Active = Convert.ToString(result[36].translations[0].text.Value),
                    UPC = Convert.ToString(result[37].translations[0].text.Value),
                    Barcode = Convert.ToString(result[38].translations[0].text.Value),
                    PDDBPieceWeight = Convert.ToString(result[39].translations[0].text.Value),
                    PDDBPieceThickness = Convert.ToString(result[40].translations[0].text.Value),
                    PDDBPieceLength = Convert.ToString(result[41].translations[0].text.Value),
                    PDDBPieceWidth = Convert.ToString(result[42].translations[0].text.Value),
                    PDDBPieceDiagonal = Convert.ToString(result[43].translations[0].text.Value),

                    ThirtyDramCapacity = Convert.ToString(result[44].translations[0].text.Value),
                    _13dram = Convert.ToString(result[45].translations[0].text.Value),
                    ImprintSide1 = Convert.ToString(result[46].translations[0].text.Value),
                    ImprintSide2 = Convert.ToString(result[47].translations[0].text.Value),
                    Clarity = Convert.ToString(result[48].translations[0].text.Value),
                    Coating = Convert.ToString(result[49].translations[0].text.Value),
                    Color = Convert.ToString(result[50].translations[0].text.Value),
                    Flavor = Convert.ToString(result[51].translations[0].text.Value),
                    Scoring = Convert.ToString(result[52].translations[0].text.Value),
                    Shape = Convert.ToString(result[53].translations[0].text.Value),
                    NADAC = Convert.ToString(result[54].translations[0].text.Value),
                    SWP = Convert.ToString(result[55].translations[0].text.Value),
                    WAC = Convert.ToString(result[56].translations[0].text.Value),
                    ATPCanisterNo = Convert.ToString(result[57].translations[0].text.Value),
                    TCGDiameter = Convert.ToString(result[58].translations[0].text.Value),
                    TCGLength = Convert.ToString(result[59].translations[0].text.Value),
                    BeaconBottleHeight = Convert.ToString(result[60].translations[0].text.Value),
                    BeaconBottleWidth = Convert.ToString(result[61].translations[0].text.Value),
                    BeaconBottleDepth = Convert.ToString(result[62].translations[0].text.Value),
                    MaxOrMiniCanisterHeightSetting = Convert.ToString(result[63].translations[0].text.Value),
                    MaxOrMiniCanisterWidthSetting = Convert.ToString(result[64].translations[0].text.Value),
                    MaxOrMiniCanisterPressureSetting = Convert.ToString(result[65].translations[0].text.Value),
                    MaxOrMiniCanisterBaffleSetting = Convert.ToString(result[66].translations[0].text.Value),
                    PassRecipe = Convert.ToString(result[67].translations[0].text.Value),
                    DivisionBlockID = Convert.ToString(result[68].translations[0].text.Value),
                    BrushID = Convert.ToString(result[69].translations[0].text.Value),
                    GuideBlockID = Convert.ToString(result[70].translations[0].text.Value),
                    SlotLocationID = Convert.ToString(result[71].translations[0].text.Value),
                    HandleID = Convert.ToString(result[72].translations[0].text.Value),
                    BlockID = Convert.ToString(result[73].translations[0].text.Value),
                    GelPadID = Convert.ToString(result[74].translations[0].text.Value),




                };

                return SynMedDrugDtoModel;
            }
        }
    }

    public class Translation
    {
        public object text { get; set; }
        public string to { get; set; }
    }

    public class TranslateValue
    {
        public string Text { get; set; }
    }
    public class Root
    {
        public ICollection<Translation> translations { get; set; }
    }


    public class SynMedDrugDtoTranslate
    {
        public string otc_flag { get; set; }

        public string local_drug_id { get; set; }
        public string drug_picture { get; set; }
        public string primary_drug_name { get; set; }
        public string concentration { get; set; }
        //public String manufacturer { get; set; }
        public string pipette_size { get; set; }
        public string lid_hole_size { get; set; }
        public string lid_volcanic { get; set; }
        public string toggle_flag { get; set; }
        public string fragile_flag { get; set; }
        public string dispensing_height { get; set; }
        public string mass_index { get; set; }
        public string mass_index_concat { get; set; }
        public string camera_set { get; set; }
        public string length { get; set; }
        public string added_timestamp { get; set; }
        public string filename { get; set; }

        ///// Drug Table

        public string LastUpdated { get; set; }
        public string NationalDrugCode { get; set; }
        public string FDBID { get; set; }
        public string LabelName { get; set; }
        public string DrugName { get; set; }
        public string GenericNameIndicator { get; set; }
        public string GenericSequenceNumber { get; set; }
        public ICollection<FDBPhoneticDto> FDBPhonetic { get; set; }
        public string Strength { get; set; }
        public string PackageSize { get; set; }
        public string Manufacturer { get; set; }
        public string Schedule { get; set; }
        public string StrengthUnitOfMeasure { get; set; }
        public string RouteOfAdminAbbr { get; set; }
        public string RouteOfAdministration { get; set; }
        public string OTC { get; set; }
        public string Storageconditions { get; set; }
        public string NIOSH { get; set; }
        public string Packaging { get; set; }
        public string UnitDoseIndicator { get; set; }
        public string UnitOfUseIndicator { get; set; }
        public string TallManName { get; set; }
        public ICollection<FDBLabelWarningDto> FDBLabelWarning { get; set; }
        public string DosageForm { get; set; }
        public string Active { get; set; }
        public string UPC { get; set; }
        public string Barcode { get; set; }
        public string PDDBPieceWeight { get; set; }
        public string PDDBPieceThickness { get; set; }
        public string PDDBPieceLength { get; set; }
        public string PDDBPieceWidth { get; set; }
        public string PDDBPieceDiagonal { get; set; }
        public string ThirtyDramCapacity { get; set; }
        public string _13dram { get; set; }
        public string ImprintSide1 { get; set; }
        public string ImprintSide2 { get; set; }
        public string Clarity { get; set; }
        public string Coating { get; set; }
        public string Color { get; set; }
        public string Flavor { get; set; }
        public string Scoring { get; set; }
        public string Shape { get; set; }
        public string NADAC { get; set; }
        public string SWP { get; set; }
        public string WAC { get; set; }
        public string ATPCanisterNo { get; set; }
        public string TCGDiameter { get; set; }
        public string TCGLength { get; set; }
        public string BeaconBottleHeight { get; set; }
        public string BeaconBottleWidth { get; set; }
        public string BeaconBottleDepth { get; set; }
        public string MaxOrMiniCanisterHeightSetting { get; set; }
        public string MaxOrMiniCanisterWidthSetting { get; set; }
        public string MaxOrMiniCanisterPressureSetting { get; set; }
        public string MaxOrMiniCanisterBaffleSetting { get; set; }
        public string PassRecipe { get; set; }
        public string DivisionBlockID { get; set; }
        public string BrushID { get; set; }
        public string GuideBlockID { get; set; }
        public string SlotLocationID { get; set; }
        public string HandleID { get; set; }
        public string BlockID { get; set; }
        public string GelPadID { get; set; }
        public ICollection<FDBImagesDto> FDBImage { get; set; }
    }


    public class SynMedDrugDto
    {
        public Boolean? otc_flag { get; set; }

        public String local_drug_id { get; set; }
        public String drug_picture { get; set; }
        public String primary_drug_name { get; set; }
        public String concentration { get; set; }
        //public String manufacturer { get; set; }
        public int? pipette_size { get; set; }
        public int? lid_hole_size { get; set; }
        public Boolean? lid_volcanic { get; set; }
        public Boolean? toggle_flag { get; set; }
        public Boolean? fragile_flag { get; set; }
        public String dispensing_height { get; set; }
        public int? mass_index { get; set; }
        public int? mass_index_concat { get; set; }
        public String camera_set { get; set; }
        public String length { get; set; }
        public DateTime? added_timestamp { get; set; }
        public String filename { get; set; }

        ///// Drug Table

        public DateTime? LastUpdated { get; set; }
        public String NationalDrugCode { get; set; }
        public Decimal? FDBID { get; set; }
        public String LabelName { get; set; }
        public String DrugName { get; set; }
        public String GenericNameIndicator { get; set; }
        public Decimal? GenericSequenceNumber { get; set; }
        public ICollection<FDBPhoneticDto> FDBPhonetic { get; set; }
        public String Strength { get; set; }
        public Decimal? PackageSize { get; set; }
        public String Manufacturer { get; set; }
        public String Schedule { get; set; }
        public String StrengthUnitOfMeasure { get; set; }
        public String RouteOfAdminAbbr { get; set; }
        public String RouteOfAdministration { get; set; }
        public String OTC { get; set; }
        public String Storageconditions { get; set; }
        public String NIOSH { get; set; }
        public String Packaging { get; set; }
        public String UnitDoseIndicator { get; set; }
        public String UnitOfUseIndicator { get; set; }
        public String TallManName { get; set; }
        public ICollection<FDBLabelWarningDto> FDBLabelWarning { get; set; }
        public String DosageForm { get; set; }
        public String Active { get; set; }
        public String UPC { get; set; }
        public String Barcode { get; set; }
        public Double? PDDBPieceWeight { get; set; }
        public Double? PDDBPieceThickness { get; set; }
        public Double? PDDBPieceLength { get; set; }
        public Double? PDDBPieceWidth { get; set; }
        public Double? PDDBPieceDiagonal { get; set; }
        public int? ThirtyDramCapacity { get; set; }
        public Boolean? _13dram { get; set; }
        public String ImprintSide1 { get; set; }
        public String ImprintSide2 { get; set; }
        public String Clarity { get; set; }
        public String Coating { get; set; }
        public String Color { get; set; }
        public String Flavor { get; set; }
        public String Scoring { get; set; }
        public String Shape { get; set; }
        public Decimal? NADAC { get; set; }
        public Decimal? SWP { get; set; }
        public Decimal? WAC { get; set; }
        public String ATPCanisterNo { get; set; }
        public Decimal? TCGDiameter { get; set; }
        public Decimal? TCGLength { get; set; }
        public Double? BeaconBottleHeight { get; set; }
        public Double? BeaconBottleWidth { get; set; }
        public Double? BeaconBottleDepth { get; set; }
        public Double? MaxOrMiniCanisterHeightSetting { get; set; }
        public String MaxOrMiniCanisterWidthSetting { get; set; }
        public int? MaxOrMiniCanisterPressureSetting { get; set; }
        public int? MaxOrMiniCanisterBaffleSetting { get; set; }
        public string PassRecipe { get; set; }
        public int? DivisionBlockID { get; set; }
        public int? BrushID { get; set; }
        public int? GuideBlockID { get; set; }
        public int? SlotLocationID { get; set; }
        public int? HandleID { get; set; }
        public int? BlockID { get; set; }
        public int? GelPadID { get; set; }
        public ICollection<FDBImagesDto> FDBImage { get; set; }
    }
    public class FDBImagesDto
    {
        public String TabletImage { get; set; }

        public Byte[] BinaryImage { get; set; }
    }
    public class FDBLabelWarningDto
    {
        public Decimal? Priority { get; set; }
        public String Description { get; set; }
    }
    public class FDBPhoneticDto
    {
        public Decimal? PEMONOE_SN { get; set; }
        public String PEMTXTE { get; set; }
    }

}
