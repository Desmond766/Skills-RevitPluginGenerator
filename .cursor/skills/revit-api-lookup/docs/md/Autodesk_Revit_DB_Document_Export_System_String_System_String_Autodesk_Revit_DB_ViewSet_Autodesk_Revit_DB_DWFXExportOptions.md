---
kind: method
id: M:Autodesk.Revit.DB.Document.Export(System.String,System.String,Autodesk.Revit.DB.ViewSet,Autodesk.Revit.DB.DWFXExportOptions)
zh: 导出、输出
source: html/d055fb60-5271-a2f6-de50-eb0d03911986.htm
---
# Autodesk.Revit.DB.Document.Export Method

**中文**: 导出、输出

Exports the current view or a selection of views in DWFX format.

## Syntax (C#)
```csharp
public bool Export(
	string folder,
	string name,
	ViewSet views,
	DWFXExportOptions options
)
```

## Parameters
- **folder** (`System.String`) - Output folder, into which file(s) will be exported. The folder must exist.
- **name** (`System.String`) - Either the name of a single file or a prefix for a set of files.
 If Nothing nullptr a null reference ( Nothing in Visual Basic) or empty, automatic naming will be used.
- **views** (`Autodesk.Revit.DB.ViewSet`) - Selection of views to be exported.
- **options** (`Autodesk.Revit.DB.DWFXExportOptions`) - Various options applicable to the DWFX format.
 If Nothing nullptr a null reference ( Nothing in Visual Basic) , all options will be set to their respective default values.

## Returns
Function returns true only if all specified views are exported successfully.
The function returns False if exporting of any view fails, even if some views might have been exported successfully.

## Remarks
All the views must be printable in order for the Export to succeed.
It can be assured by checking the CanBePrinted property of each view.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when the input views is Nothing nullptr a null reference ( Nothing in Visual Basic)
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when the input views is an empty ViewSet.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when the current document is not modifiable.

