---
kind: method
id: M:Autodesk.Revit.DB.InstanceVoidCutUtils.AddInstanceVoidCut(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.Element,Autodesk.Revit.DB.Element)
source: html/378b57d2-db9f-f103-678c-64d82757997e.htm
---
# Autodesk.Revit.DB.InstanceVoidCutUtils.AddInstanceVoidCut Method

Add a cut to an element using the unattached voids inside a cutting instance.

## Syntax (C#)
```csharp
public static void AddInstanceVoidCut(
	Document document,
	Element element,
	Element cuttingInstance
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document containing the two elements
- **element** (`Autodesk.Revit.DB.Element`) - The element to be cut
- **cuttingInstance** (`Autodesk.Revit.DB.Element`) - The cutting family instance

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The element cannot be cut with a void instance.
 -or-
 The element is not a family instance with an unattached void that can cut.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ForbiddenForDynamicUpdateException** - This method may not be called during dynamic update.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Failed to cut element with the instances

