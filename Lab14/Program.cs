using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab14 {
    //https://docs.google.com/spreadsheets/d/10o2V0AYIgbfSinFaLhILeUEKVm_b-7KT7N6F1GQNszo/edit?usp=sharing
    class Program {
        static readonly string[] Scopes = { SheetsService.Scope.Spreadsheets };
        static readonly string ApplicationName = "test1";
        static readonly string sheet = "Лист1";
        static readonly string SpreadsheetId = "10o2V0AYIgbfSinFaLhILeUEKVm_b-7KT7N6F1GQNszo";
        static SheetsService service;

        static void Main(string[] args) {
            Init();
            ReadSheet();
            AddRow();
            UpdateCell();

        }

        static void Init() {

            GoogleCredential credential;
            //Reading Credentials File...
            using (var stream = new FileStream("GXls.json", FileMode.Open, FileAccess.Read)) {
                credential = GoogleCredential.FromStream(stream)
                    .CreateScoped(Scopes);
            }

            // Creating Google Sheets API service...
            service = new SheetsService(new BaseClientService.Initializer() {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });
        }

        static void ReadSheet() {
            var range = $"{sheet}!A:C";
            SpreadsheetsResource.ValuesResource.GetRequest request =
                    service.Spreadsheets.Values.Get(SpreadsheetId, range);

            var response = request.Execute();
            IList<IList<object>> values = response.Values;
            if (values != null && values.Count > 0) {
                foreach (var row in values) {
                    Console.WriteLine("{0} | {1} | {2}", row[0], row[1], row[2]);
                }
            } else {
                Console.WriteLine("No data found.");
            }
        }

        static void AddRow() {
            var range = $"{sheet}!A:C";
            var valueRange = new ValueRange();
            var oblist = new List<object>() { "5", "zxcvbn", "77" };
            valueRange.Values = new List<IList<object>> { oblist };
            var appendRequest = service.Spreadsheets.Values.Append(valueRange, SpreadsheetId, range);
            appendRequest.ValueInputOption = SpreadsheetsResource.ValuesResource.AppendRequest.ValueInputOptionEnum.USERENTERED;
            var appendReponse = appendRequest.Execute();
        }

        static void UpdateCell() {
            var range = $"{sheet}!B5:C5";
            var valueRange = new ValueRange();
            var oblist = new List<object>() { "update", "32" };
            valueRange.Values = new List<IList<object>> { oblist };

            var updateRequest = service.Spreadsheets.Values.Update(valueRange, SpreadsheetId, range);
            updateRequest.ValueInputOption = SpreadsheetsResource.ValuesResource.UpdateRequest.ValueInputOptionEnum.USERENTERED;
            var appendReponse = updateRequest.Execute();
        }

    }
}
