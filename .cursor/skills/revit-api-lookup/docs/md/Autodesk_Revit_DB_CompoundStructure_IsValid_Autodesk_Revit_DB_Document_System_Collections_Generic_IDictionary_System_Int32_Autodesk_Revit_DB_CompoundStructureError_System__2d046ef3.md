---
kind: method
id: M:Autodesk.Revit.DB.CompoundStructure.IsValid(Autodesk.Revit.DB.Document,System.Collections.Generic.IDictionary{System.Int32,Autodesk.Revit.DB.CompoundStructureError}@,System.Collections.Generic.IDictionary{System.Int32,System.Int32}@)
source: html/e77d2eba-f2fd-b2f6-c008-ccf45826a784.htm
---
# Autodesk.Revit.DB.CompoundStructure.IsValid Method

Checks for errors or inconsistencies in the data in this CompoundStructure.

## Syntax (C#)
```csharp
public bool IsValid(
	Document doc,
	out IDictionary<int, CompoundStructureError> errMap,
	out IDictionary<int, int> twoLayerErrorsMap
)
```

## Parameters
- **doc** (`Autodesk.Revit.DB.Document`) - Access to the document in which the CompoundStructure will be used.
- **errMap** (`System.Collections.Generic.IDictionary < Int32 , CompoundStructureError > %`) - This map will associate each problematic layer index to a value in CompoundStructureError.
 General structure errors are reported as associated to layer index -1.
- **twoLayerErrorsMap** (`System.Collections.Generic.IDictionary < Int32 , Int32 > %`) - The map is associated to a check run only for vertically Compound Structures.
 Essentially the Compound Structure is sliced at representative heights.
 It looks at the region from exterior to interior, and requires that the assigned layer indices do not decrease.
 If they do, an entry is generated for this map. The first entry is the last valid layer index encountered.
 The second entry is a region id whose assigned layer index is too small: it should be at least as large as the first entry.

## Returns
True if the compound structure is valid for the document, false otherwise.

## Remarks
This check is run before the CompoundStructure may be assigned to a particular ElementType.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

