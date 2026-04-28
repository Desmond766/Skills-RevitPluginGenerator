---
kind: method
id: M:Autodesk.Revit.DB.Mechanical.DuctSizeSettings.GetSizeCount(Autodesk.Revit.DB.Mechanical.DuctShape)
source: html/3fbdf755-b50c-4d08-8a56-dac84a37e12a.htm
---
# Autodesk.Revit.DB.Mechanical.DuctSizeSettings.GetSizeCount Method

Get the size count of the duct size table. The duct shape determines the location of the size in the size table.

## Syntax (C#)
```csharp
public int GetSizeCount(
	DuctShape shape
)
```

## Parameters
- **shape** (`Autodesk.Revit.DB.Mechanical.DuctShape`) - The shape of duct.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

