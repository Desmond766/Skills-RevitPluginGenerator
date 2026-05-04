---
kind: method
id: M:Autodesk.Revit.DB.InstanceVoidCutUtils.RemoveInstanceVoidCut(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.Element,Autodesk.Revit.DB.Element)
source: html/828d0706-b0fd-2349-cd77-ed6062e8d24a.htm
---
# Autodesk.Revit.DB.InstanceVoidCutUtils.RemoveInstanceVoidCut Method

Remove a cut applied to the element by a cutting instance with unattached voids.

## Syntax (C#)
```csharp
public static void RemoveInstanceVoidCut(
	Document document,
	Element element,
	Element cuttingInstance
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document containing the two elements
- **element** (`Autodesk.Revit.DB.Element`) - The element being cut
- **cuttingInstance** (`Autodesk.Revit.DB.Element`) - The cutting family instance

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - No instance void cut exists between the two elements.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Failed to remove the instance cut from the element

