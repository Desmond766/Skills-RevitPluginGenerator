---
kind: method
id: M:Autodesk.Revit.DB.IExportContext2D.OnElementEnd2D(Autodesk.Revit.DB.ElementNode)
source: html/2547072a-3cbf-dc85-aab9-9424f95119be.htm
---
# Autodesk.Revit.DB.IExportContext2D.OnElementEnd2D Method

This method marks the end of an element being exported.

## Syntax (C#)
```csharp
void OnElementEnd2D(
	ElementNode node
)
```

## Parameters
- **node** (`Autodesk.Revit.DB.ElementNode`) - An output node that represents an element.

## Remarks
For views having non-Wireframe display style, geometry of elements is output outside of view, instance and link begin/end brackets.
 Therefore the argument to this method is ElementNode that has both element ID and the host document.

