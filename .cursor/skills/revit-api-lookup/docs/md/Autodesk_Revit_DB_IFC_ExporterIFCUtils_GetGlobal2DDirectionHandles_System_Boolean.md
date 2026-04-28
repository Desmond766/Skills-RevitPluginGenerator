---
kind: method
id: M:Autodesk.Revit.DB.IFC.ExporterIFCUtils.GetGlobal2DDirectionHandles(System.Boolean)
source: html/8dd68058-098b-2536-a5b2-8245c40a71bf.htm
---
# Autodesk.Revit.DB.IFC.ExporterIFCUtils.GetGlobal2DDirectionHandles Method

Obtains the handles representing the cardinal directions in 2D.

## Syntax (C#)
```csharp
public static IList<IFCAnyHandle> GetGlobal2DDirectionHandles(
	bool positive
)
```

## Parameters
- **positive** (`System.Boolean`) - True if the handles returned should be in the positive direction, false
 if the handles should be in the negative direction.

## Returns
The collection of handles.

