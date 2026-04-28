---
kind: method
id: M:Autodesk.Revit.DB.FabricationPart.SaveAsFabricationJob(Autodesk.Revit.DB.Document,System.Collections.Generic.ISet{Autodesk.Revit.DB.ElementId},System.String,Autodesk.Revit.DB.Fabrication.FabricationSaveJobOptions)
source: html/c443a64a-7541-ed57-c641-ec54d3576a00.htm
---
# Autodesk.Revit.DB.FabricationPart.SaveAsFabricationJob Method

Save fabrication parts to an MEP job that can be opened in the fabrication software.

## Syntax (C#)
```csharp
public static ISet<ElementId> SaveAsFabricationJob(
	Document document,
	ISet<ElementId> ids,
	string filename,
	FabricationSaveJobOptions saveOptions
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document.
- **ids** (`System.Collections.Generic.ISet < ElementId >`) - List of element Ids of fabrication parts or assemblies and group elements that contain fabrication parts to save. Non-fabrication part elements will be ignored.
- **filename** (`System.String`) - The full path and filename of the fabrication job to save.
- **saveOptions** (`Autodesk.Revit.DB.Fabrication.FabricationSaveJobOptions`) - Options for the save operation.

## Returns
Returns a list of fabrication part element Ids that were saved to the fabrication job.

## Remarks
Only fabrication MAJ files are supported.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Fabrication configuration is missing.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - the path to the filename must already exist and be writeable
- **Autodesk.Revit.Exceptions.InvalidPathArgumentException** - The destination file name includes one or more invalid characters.

