---
kind: method
id: M:Autodesk.Revit.DB.IFC.ExporterIFCUtils.CreateProjectLevelGUID(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.IFC.IFCProjectLevelGUIDType)
source: html/4b93559d-3541-5740-11f1-87f202977be5.htm
---
# Autodesk.Revit.DB.IFC.ExporterIFCUtils.CreateProjectLevelGUID Method

Creates a GUID from Revit project for given GUIDType.

## Syntax (C#)
```csharp
public static string CreateProjectLevelGUID(
	Document document,
	IFCProjectLevelGUIDType guidType
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document.
- **guidType** (`Autodesk.Revit.DB.IFC.IFCProjectLevelGUIDType`) - The GUID type.

## Returns
The guid string.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

