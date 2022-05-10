namespace EquipManager.Services.Com.Word;

public class WordDocumentService
{
    private readonly Dictionary<string, string> _dictionary = new();

    public bool Process()
    {
        SaveFileDialog saveFileDialog = new();

        string? fileDirectory;
        string fileName;

        saveFileDialog.Filter = $"Document Word (*.docx)|*.docx| AllFiles (*.*)|*.*";
        saveFileDialog.FilterIndex = 1;
        saveFileDialog.RestoreDirectory = true;

        saveFileDialog.Title = "Select the file directory";
        saveFileDialog.FileName = $"Contract {DateTime.Now:dd.MM.yy(HH.mm)}";

        if (saveFileDialog.ShowDialog() is DialogResult.OK)
        {
            if (string.IsNullOrEmpty(saveFileDialog.FileName) is false)
            {
                fileName = Path.GetFileName(path: saveFileDialog.FileName);

                fileDirectory = Path.GetDirectoryName(path: saveFileDialog.FileName);

                if (string.IsNullOrWhiteSpace(value: fileDirectory)) return false;

                using WordDocument document = new();

                Stream docStream = File.OpenRead(path: Path.GetFullPath(path: @"../../../Contract.docx"));

                document.Open(stream: docStream, formatType: FormatType.Docx);

                docStream.Dispose();

                foreach (var item in _dictionary)
                    document.Replace(item.Key, item.Value, true, true);

                docStream = File.Create(path: $"{fileDirectory}/{fileName}");

                document.Save(stream: docStream, formatType: FormatType.Docx);

                docStream.Dispose();

                return true;
            }
        }

        return false;
    }

    public bool Process(PPEContract contract)
    {
        SaveFileDialog saveFileDialog = new();

        string? fileDirectory;
        string fileName;

        saveFileDialog.Filter = $"Document Word (*.docx)|*.docx| All Files (*.*)|*.*";
        saveFileDialog.FilterIndex = 1;
        saveFileDialog.RestoreDirectory = true;

        saveFileDialog.Title = "Select the file directory";
        saveFileDialog.FileName = $"Contract {DateTime.Now:dd.MM.yy(HH.mm)}";

        if (saveFileDialog.ShowDialog() is DialogResult.OK)
        {
            if (string.IsNullOrEmpty(saveFileDialog.FileName) is false)
            {
                fileName = Path.GetFileName(path: saveFileDialog.FileName);

                fileDirectory = Path.GetDirectoryName(path: saveFileDialog.FileName);

                if (string.IsNullOrWhiteSpace(value: fileDirectory)) return false;

                using WordDocument document = new();

                Stream docStream = File.OpenRead(path: Path.GetFullPath(path: @"../../../Contract.docx"));

                document.Open(stream: docStream, formatType: FormatType.Docx);

                docStream.Dispose();

                MapPPEContract(contract);

                foreach (var item in _dictionary)
                    document.Replace(item.Key, item.Value, true, true);

                docStream = File.Create(path: $"{fileDirectory}/{fileName}");

                document.Save(stream: docStream, formatType: FormatType.Docx);

                docStream.Dispose();

                return true;
            }
        }

        return false;
    }

    public void AppendChange(string? key, string? value)
    {
        if (string.IsNullOrWhiteSpace(key) || value is null) return;

        _dictionary.Add(key, value);
    }

    private void MapPPEContract(PPEContract contract)
    {
        MapEmployee(contract.Employee);

        MapEmployeeSizeChart(contract.Employee?.EmployeeSizeChart);

        MapPPEContractBody(contract.PPEContractBody);

        AppendChange(key: "<PPEContract_Id>", contract.Id.ToString());
    }

    private void MapEmployee(Employee? employee)
    {
        if (employee is null) return;

        AppendChange(key: "<Employee_Id>", employee.Id.ToString());
        AppendChange(key: "<Employee_Surname>", employee.Surname);
        AppendChange(key: "<Employee_Name>", employee.Name);
        AppendChange(key: "<Employee_Profession>", employee.Profession);
        AppendChange(key: "<Employee_StructuralDivision>", employee.StructuralDivision);
        AppendChange(key: "<Employee_DateOfEmployment>", employee.DateOfEmployment.ToString(format: "dd.MM.yy"));
        AppendChange(key: "<Employee_DateOfProfessionChange>", employee.DateOfProfessionChange.ToString(format: "dd.MM.yy"));
        AppendChange(key: "<Employee_Height>", employee.Height.ToString());
        AppendChange(key: "<Employee_Gender>", employee.Gender);
    }

    private void MapEmployeeSizeChart(EmployeeSizeChart? sizeChart)
    {
        if (sizeChart is null) return;

        AppendChange(key: "<SizeChart_Cloth>", sizeChart.Cloth.ToString());
        AppendChange(key: "<SizeChart_Shoes>", sizeChart.Shoes.ToString());
        AppendChange(key: "<SizeChart_Head>", sizeChart.Headdress.ToString());
        AppendChange(key: "<SizeChart_GasMask>", sizeChart.GazMask.ToString());
        AppendChange(key: "<SizeChart_Respirator>", sizeChart.Respirator.ToString());
        AppendChange(key: "<SizeChart_Sleeve>", sizeChart.Sleeve.ToString());
        AppendChange(key: "<SizeChart_Glove>", sizeChart.Glove.ToString());
    }

    private void MapPPE(PPE? ppe, int number)
    {
        if (ppe is null)
        {
            AppendChange(key: $"<PPE{number}_Name>", string.Empty);
            AppendChange(key: $"<PPE{number}_Unit>", string.Empty);
            AppendChange(key: $"<PPE{number}_Quantity>", string.Empty);
            AppendChange(key: $"<PPE{number}_Certificate>", string.Empty);

            return;
        }

        AppendChange(key: $"<PPE{number}_Name>", ppe.Name);
        AppendChange(key: $"<PPE{number}_Unit>", ppe.UnitOfMeasurement);
        AppendChange(key: $"<PPE{number}_Quantity>", ppe.QuantityPerYear.ToString());
        AppendChange(key: $"<PPE{number}_Certificate>", ppe.CertificateOfConformity);
    }

    private void MapPPEContractBody(PPEContractBody? body)
    {
        if (body is null) return;

        MapPPE(ppe: body.PPE1, number: 1);
        MapPPE(ppe: body.PPE2, number: 2);
        MapPPE(ppe: body.PPE3, number: 3);
        MapPPE(ppe: body.PPE4, number: 4);
        MapPPE(ppe: body.PPE5, number: 5);
        MapPPE(ppe: body.PPE6, number: 6);
        MapPPE(ppe: body.PPE7, number: 7);
        MapPPE(ppe: body.PPE8, number: 8);
        MapPPE(ppe: body.PPE9, number: 9);
        MapPPE(ppe: body.PPE10, number: 10);
        MapPPE(ppe: body.PPE11, number: 11);
        MapPPE(ppe: body.PPE12, number: 12);
    }
}