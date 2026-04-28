---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarPropagation.AlignByFace(Autodesk.Revit.DB.Document,System.Collections.Generic.IList{Autodesk.Revit.DB.Structure.Rebar},Autodesk.Revit.DB.Reference,Autodesk.Revit.DB.Reference)
source: html/bbfb8474-26cd-9568-8c0f-8dd5d4052c8f.htm
---
# Autodesk.Revit.DB.Structure.RebarPropagation.AlignByFace Method

It will copy the source rebars, will align them to the destination face based on the source face and adapt them to destination host.

## Syntax (C#)
```csharp
public static ISet<ElementId> AlignByFace(
	Document doc,
	IList<Rebar> sourceRebars,
	Reference sourceFaceReference,
	Reference destinationFaceReference
)
```

## Parameters
- **doc** (`Autodesk.Revit.DB.Document`) - A document.
- **sourceRebars** (`System.Collections.Generic.IList < Rebar >`) - The rebars that will be propagated. All of them must be from the same host as the source face reference.
- **sourceFaceReference** (`Autodesk.Revit.DB.Reference`) - A reference to a face in the source host.
- **destinationFaceReference** (`Autodesk.Revit.DB.Reference`) - A reference to a face in the destions host.

## Returns
The newly created rebars.

## Remarks
The source and destination hosts represented by the source and destination references can be the same element or can be difereent elements. They can also be of different categories The destination host must be able to host rebar. The source rebars should not be gourp members. This method uses its own transaction, so it's not permitted to be invoked in an active transaction.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The element that contains the destinationFaceReference is not a valid rebar host.
 -or-
 The rebars should be from the same host as the source face reference.
 -or-
 The rebars that are group members can't be propagated.
 -or-
 The references should represent faces that have same type of surface.
 -or-
 The source and destination face references should be different.
 -or-
 This method uses its own transaction, so it's not permitted to be invoked in an active transaction.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

