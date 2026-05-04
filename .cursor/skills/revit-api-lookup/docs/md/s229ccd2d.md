---
kind: method
id: M:Autodesk.Revit.DB.IFC.ExporterIFCUtils.GetGlobal3DDirectionHandles(System.Boolean)
source: html/53f5d108-2d95-4c76-c3f5-5f5f82f3b325.htm
---
# Autodesk.Revit.DB.IFC.ExporterIFCUtils.GetGlobal3DDirectionHandles Method

Obtains the handles representing the cardinal directions in 3D.

## Syntax (C#)
```csharp
public static IList<IFCAnyHandle> GetGlobal3DDirectionHandles(
	bool positive
)
```

## Parameters
- **positive** (`System.Boolean`) - True if the handles returned should be in the positive direction, false
 if the handles should be in the negative direction.

## Returns
The collection of handles.

