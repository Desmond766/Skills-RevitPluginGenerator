---
kind: method
id: M:Autodesk.Revit.DB.Structure.AreaLoad.GetRefPoint(System.Int32)
source: html/3bd2e404-2705-ad16-42c3-42c808890bb4.htm
---
# Autodesk.Revit.DB.Structure.AreaLoad.GetRefPoint Method

Returns the physical location of the reference point.

## Syntax (C#)
```csharp
public XYZ GetRefPoint(
	int index
)
```

## Parameters
- **index** (`System.Int32`) - The index of the point to return.

## Remarks
The index should be between 0 and less than NumRefPoints.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when index is out of range.

