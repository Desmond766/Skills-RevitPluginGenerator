---
kind: method
id: M:Autodesk.Revit.DB.Document.Export(System.String,System.String,Autodesk.Revit.DB.ViewSet,Autodesk.Revit.DB.FBXExportOptions)
zh: 导出、输出
source: html/02b2efba-9d7c-88bc-b43e-a541e169d832.htm
---
# Autodesk.Revit.DB.Document.Export Method

**中文**: 导出、输出

Exports the document in 3D-Studio Max (FBX) format.

## Syntax (C#)
```csharp
public bool Export(
	string folder,
	string name,
	ViewSet views,
	FBXExportOptions options
)
```

## Parameters
- **folder** (`System.String`) - Output folder, into which file(s) will be exported. The folder must exist.
- **name** (`System.String`) - Either the name of a single file or a prefix for a set of files.
 If Nothing nullptr a null reference ( Nothing in Visual Basic) or empty, automatic naming will be used.
- **views** (`Autodesk.Revit.DB.ViewSet`) - Selection of views to be exported.Only 3D views are allowed.
- **options** (`Autodesk.Revit.DB.FBXExportOptions`) - Options applicable to the FBX format.

## Returns
Function returns true only if all specified views are exported successfully. 
The function returns False if exporting of any view fails, even if some views might have been exported successfully.

## Remarks
Though the 'options' argument is not currently used,
 an object still must be provided (may be Nothing nullptr a null reference ( Nothing in Visual Basic) ).

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when the input views is Nothing nullptr a null reference ( Nothing in Visual Basic)
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when the input views is an empty ViewSet.
Thrown if any view in the views is not a 3D view.

