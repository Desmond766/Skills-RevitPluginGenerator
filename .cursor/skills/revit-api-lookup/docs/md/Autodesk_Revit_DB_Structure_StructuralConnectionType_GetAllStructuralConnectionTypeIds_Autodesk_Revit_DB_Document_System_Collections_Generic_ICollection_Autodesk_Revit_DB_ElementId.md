---
kind: method
id: M:Autodesk.Revit.DB.Structure.StructuralConnectionType.GetAllStructuralConnectionTypeIds(Autodesk.Revit.DB.Document,System.Collections.Generic.ICollection{Autodesk.Revit.DB.ElementId}@)
source: html/33908a35-a8d8-dfe1-abd2-a59eaaa77045.htm
---
# Autodesk.Revit.DB.Structure.StructuralConnectionType.GetAllStructuralConnectionTypeIds Method

Collects the ids of all StructuralConnectionTypes in the document.

## Syntax (C#)
```csharp
public static void GetAllStructuralConnectionTypeIds(
	Document cda,
	out ICollection<ElementId> ids
)
```

## Parameters
- **cda** (`Autodesk.Revit.DB.Document`)
- **ids** (`System.Collections.Generic.ICollection < ElementId > %`)

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

