---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarPropagation.AlignByHost(Autodesk.Revit.DB.Document,System.Collections.Generic.IList{Autodesk.Revit.DB.Structure.Rebar},Autodesk.Revit.DB.Element)
source: html/27e94ec1-2041-4ba3-ced2-988a7f5cb166.htm
---
# Autodesk.Revit.DB.Structure.RebarPropagation.AlignByHost Method

It will copy the source rebars, will align them in the same way as how the source host is aligned to destination host and will adapt them to the destinaion host.

## Syntax (C#)
```csharp
public static ISet<ElementId> AlignByHost(
	Document doc,
	IList<Rebar> sourceRebars,
	Element destinationHost
)
```

## Parameters
- **doc** (`Autodesk.Revit.DB.Document`) - A document.
- **sourceRebars** (`System.Collections.Generic.IList < Rebar >`) - The rebars that will be propagated. All of them must be from the same host.
- **destinationHost** (`Autodesk.Revit.DB.Element`) - The destination host where the new rebar will be created.

## Returns
The newly created rebars.

## Remarks
The source and destination hosts should be of the same category. The source and destination hosts should be different elements. The destination host must be able to host rebar. The source rebars should not be gourp members. This method uses its own transaction, so it's not permitted to be invoked in an active transaction.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - There are no source rebars to propagate.
 -or-
 The rebars should be from the same host.
 -or-
 The rebars that are group members can't be propagated.
 -or-
 destinationHost is not a valid rebar host.
 -or-
 The source and destination hosts should be of the same category.
 -or-
 The source and destination hosts must be different elements.
 -or-
 This method uses its own transaction, so it's not permitted to be invoked in an active transaction.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

