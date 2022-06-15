using System;
using System.Collections.Generic;
using TranslatorText.Controllers;

namespace TranslatorText
{
    public class WeatherForecast
    {
        public static SynMedDrugDto data()
        {
            return new SynMedDrugDto()
            {

                otc_flag = true,
                local_drug_id = "000023240",
                drug_picture = "000023240",
                primary_drug_name = "CYMBALTA 30 MG CAPS",
                concentration = "30MG",
                pipette_size = 2,
                lid_hole_size = 110,
                lid_volcanic = true,
                toggle_flag = true,
                fragile_flag = true,
                dispensing_height = "",
                mass_index = 0,
                mass_index_concat = 0,
                camera_set = "",
                length = "",
                added_timestamp = DateTime.Now,
                filename = "U:\\Listes Pour Les Clients\\Dossiers De Calibration\\WIP_Calibration\\Launchers\\USA\\update_db_calibration_bypass_quarantaine_USA\\FOR-EN-09-BD_Calibration_USA_9_Digits.csv",

                NationalDrugCode = "43598056178",
                LastUpdated = new DateTime(2021, 09, 11),
                FDBID = 342317,


                LabelName = "ACCUPRIL Napa TABLET",
                DrugName = "LANSOPRAZOLE",
                GenericNameIndicator = "1",
                GenericSequenceNumber = 000018,
                FDBPhonetic = new List<FDBPhoneticDto>() {
                new FDBPhoneticDto()
                {
                     PEMONOE_SN= 11,
                     PEMTXTE ="(doo-LOX-e-teen)"
                }
            },
                Strength = "mg",
                PackageSize = 100,
                Manufacturer = "Eli Lilly & Co",

                Schedule = "C-II",
                StrengthUnitOfMeasure = "mg",
                RouteOfAdminAbbr = "",
                RouteOfAdministration = "Tablet",

                OTC = "Prescription Required",
                Storageconditions = "Store at room temperature upon receipt from MFG",

                Packaging = "CANISTER",
                UnitDoseIndicator = "0",
                UnitOfUseIndicator = "0",
                TallManName = "DULoxetine 30 mg capsule,delayed release",
                FDBLabelWarning = new List<FDBLabelWarningDto>(){
                new FDBLabelWarningDto()
                {
                     Priority= 1,
                     Description= " Read the boxed warning information for this medication."
                }
            },
                DosageForm = "HFA AEROSOL WITH ADAPTER (GRAM)",
                Active = "Active",

                UPC = "1152313141",
                Barcode = "1152313141",


                PDDBPieceWeight = 0.1214,
                PDDBPieceThickness = 0.12,
                PDDBPieceLength = 0.4,
                PDDBPieceWidth = 0.4,
                PDDBPieceDiagonal = 0.172,
                ThirtyDramCapacity = 480,
                _13dram = false,

                ImprintSide1 = "30 mg",
                ImprintSide2 = "LILLY  3240",

                Color = "white",
                Shape = "round",
                Scoring = "",
                Coating = "",
                Clarity = "clear",
                Flavor = "orange",

                NIOSH = "oblong",
                NADAC = 0,
                SWP = 0,
                WAC = 0,


                ATPCanisterNo = "C 10012",
                TCGDiameter = 4,
                TCGLength = 8,
                BeaconBottleHeight = 1.42,
                BeaconBottleWidth = 1.61,
                BeaconBottleDepth = 3.39,


                MaxOrMiniCanisterHeightSetting = 4,
                MaxOrMiniCanisterWidthSetting = "B.75",
                MaxOrMiniCanisterPressureSetting = 35,
                MaxOrMiniCanisterBaffleSetting = 3,
                PassRecipe = "801-0152",
                DivisionBlockID = 353,
                BrushID = 3,
                GuideBlockID = 4,
                SlotLocationID = 5,
                HandleID = 7,
                BlockID = 8,
                GelPadID = 9,
                FDBImage = new List<FDBImagesDto>(){
                new FDBImagesDto()
                {
                TabletImage= "LLY32400",
                }
            }



            };
        }

    }
}
