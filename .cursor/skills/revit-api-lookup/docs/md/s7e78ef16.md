---
kind: method
id: M:Autodesk.Revit.DB.InstanceVoidCutUtils.InstanceVoidCutExists(Autodesk.Revit.DB.Element,Autodesk.Revit.DB.Element)
source: html/c429ad0d-9a4e-3471-c414-fdcf2f19971f.htm
---
# Autodesk.Revit.DB.InstanceVoidCutUtils.InstanceVoidCutExists Method

Check whether the instance is cutting the element

## Syntax (C#)
```csharp
public static bool InstanceVoidCutExists(
	Element element,
	Element cuttingInstance
)
```

## Parameters
- **element** (`Autodesk.Revit.DB.Element`) - The element being cut
- **cuttingInstance** (`Autodesk.Revit.DB.Element`) - The cutting family instance

## Returns
Returns true if the instance is cutting the element.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

