---
kind: method
id: M:Autodesk.Revit.DB.RevisionNumberingSequence.GetAllRevisionNumberingSequences(Autodesk.Revit.DB.Document)
source: html/dd3dd3e5-ed85-a7e4-6280-1a0e5464f5d0.htm
---
# Autodesk.Revit.DB.RevisionNumberingSequence.GetAllRevisionNumberingSequences Method

Gets all of the revision numbering sequences from the document.

## Syntax (C#)
```csharp
public static ISet<ElementId> GetAllRevisionNumberingSequences(
	Document document
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document that contains the sequences.

## Returns
The revision numbering sequences from the document.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

