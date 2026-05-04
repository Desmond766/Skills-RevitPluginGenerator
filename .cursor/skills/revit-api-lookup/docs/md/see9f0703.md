---
kind: method
id: M:Autodesk.Revit.DB.IFC.ExporterIFCUtils.CreateSubElementGUID(Autodesk.Revit.DB.Element,System.Int32)
source: html/f982827b-fa34-be50-fe11-abc4f884f574.htm
---
# Autodesk.Revit.DB.IFC.ExporterIFCUtils.CreateSubElementGUID Method

Creates a consistent GUID for an IFC entity related to a Revit element.
 A "related" sub-element is one that is unique for a given type of element, and can
 therefore by identified by a simple index value (e.g. PSet_Wall_Common property set for a wall.)
 The index value 0 is reserved, as this would generate the GUID of the element itself.
 A listing of known sub-elements is contained in IFCSubElementEnums.cs; it is
 expected that this list would be maintained up-to-date, instead of passing arbitrary values
 into this function.

## Syntax (C#)
```csharp
public static string CreateSubElementGUID(
	Element pElement,
	int subElementIndex
)
```

## Parameters
- **pElement** (`Autodesk.Revit.DB.Element`) - The element.
- **subElementIndex** (`System.Int32`) - The global index for this sub-element.

## Returns
The guid string.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

