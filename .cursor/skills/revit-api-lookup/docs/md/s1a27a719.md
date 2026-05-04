---
kind: method
id: M:Autodesk.Revit.DB.Document.Export(System.String,System.String,Autodesk.Revit.DB.GBXMLExportOptions)
zh: 导出、输出
source: html/adf1b78e-dcab-7b46-80fa-a470f0fd848b.htm
---
# Autodesk.Revit.DB.Document.Export Method

**中文**: 导出、输出

Export the model in gbXML (green-building) format.

## Syntax (C#)
```csharp
public bool Export(
	string folder,
	string name,
	GBXMLExportOptions options
)
```

## Parameters
- **folder** (`System.String`) - Indicates the path of a folder where to export the gbXML file.
- **name** (`System.String`) - Indicates the name of the gbXML file to export. If it doesn't end with ".xml", extension ".xml" will be added automatically. The name cannot contain any of the following characters: \/:*?"<>|. Empty name is not acceptable.
- **options** (`Autodesk.Revit.DB.GBXMLExportOptions`) - Options which control the contents of the export.

## Returns
True if successful, otherwise False.

## Remarks
This export operation will operate on the main EnergyAnalysisDetailModel in the document, if it exists (see EnergyAnalysisDetailModel.GetMainEnergyAnalysisDetailModel()).
 If it does not exist, or if the requested ExportEnergyModelType does not match the type of the main EnergyAnalysisDetailModel, this function will fail.
 If you need to export a model with different settings or type than the current main energy model in the document, you should delete the current main energy model, update the EnergyAnalysisSettings, and regenerate the energy model.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The path is not valid for exporting gbXML files.
 -or-
 The name is empty or not valid for exporting gbXML files.
 -or-
 Analysis type is invalid. For AnalysisMode.ConceptualMasses, use Document.Export(String, String, MassGBXMLExportOptions).
 -or-
 There is no main EnergyAnalysisDetailModel in the document, or the current main EnergyAnalysisDetailModel is not compatible with the option set in the GBXMLExportOptions.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Exporting is not allowed in the current application mode.
 -or-
 Export is temporarily disabled.

