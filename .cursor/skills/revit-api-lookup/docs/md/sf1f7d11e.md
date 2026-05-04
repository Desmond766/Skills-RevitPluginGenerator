---
kind: method
id: M:Autodesk.Revit.DB.InstanceVoidCutUtils.GetCuttingVoidInstances(Autodesk.Revit.DB.Element)
source: html/79d10f4e-9ab1-adfb-f89d-c5c754712b23.htm
---
# Autodesk.Revit.DB.InstanceVoidCutUtils.GetCuttingVoidInstances Method

Return ids of the instances with unattached voids cutting the element.

## Syntax (C#)
```csharp
public static ICollection<ElementId> GetCuttingVoidInstances(
	Element element
)
```

## Parameters
- **element** (`Autodesk.Revit.DB.Element`) - The element being cut

## Returns
Ids of instances with unattached voids that cut this element

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

