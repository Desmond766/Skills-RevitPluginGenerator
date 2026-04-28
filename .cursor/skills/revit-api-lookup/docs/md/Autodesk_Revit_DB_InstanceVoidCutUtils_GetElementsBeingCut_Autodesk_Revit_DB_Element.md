---
kind: method
id: M:Autodesk.Revit.DB.InstanceVoidCutUtils.GetElementsBeingCut(Autodesk.Revit.DB.Element)
source: html/e709fbe6-5508-6212-07d6-cefd3c095d9e.htm
---
# Autodesk.Revit.DB.InstanceVoidCutUtils.GetElementsBeingCut Method

Return ids of the elements being cut by the instance

## Syntax (C#)
```csharp
public static ICollection<ElementId> GetElementsBeingCut(
	Element cuttingInstance
)
```

## Parameters
- **cuttingInstance** (`Autodesk.Revit.DB.Element`) - The cutting family instance

## Returns
Ids of elements being cut by cuttingInstance

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

