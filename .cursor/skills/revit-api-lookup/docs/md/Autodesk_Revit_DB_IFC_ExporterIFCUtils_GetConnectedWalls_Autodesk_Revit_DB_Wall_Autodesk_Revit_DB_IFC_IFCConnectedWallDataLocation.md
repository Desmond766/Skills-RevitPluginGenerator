---
kind: method
id: M:Autodesk.Revit.DB.IFC.ExporterIFCUtils.GetConnectedWalls(Autodesk.Revit.DB.Wall,Autodesk.Revit.DB.IFC.IFCConnectedWallDataLocation)
source: html/d2199e0e-f7f0-0c4b-cf62-d51773f95d02.htm
---
# Autodesk.Revit.DB.IFC.ExporterIFCUtils.GetConnectedWalls Method

Obtains the IFC-specific information regarding the connections between this wall and other elements.

## Syntax (C#)
```csharp
public static IList<IFCConnectedWallData> GetConnectedWalls(
	Wall pWallElem,
	IFCConnectedWallDataLocation locaction
)
```

## Parameters
- **pWallElem** (`Autodesk.Revit.DB.Wall`) - The wall.
- **locaction** (`Autodesk.Revit.DB.IFC.IFCConnectedWallDataLocation`) - The location on the wall from where the connections should be obtained. This should be either
 IFCConnectedWallDataLocation.Start or IFCConnectedWallDataLocation.End.

## Returns
The connection information.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

