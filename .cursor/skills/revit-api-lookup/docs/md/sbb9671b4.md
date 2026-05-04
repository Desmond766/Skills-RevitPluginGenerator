---
kind: method
id: M:Autodesk.Revit.DB.Analysis.MEPNetworkIterator.#ctor(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.Analysis.MEPAnalyticalNode,Autodesk.Revit.DB.Analysis.MEPAnalyticalSegment)
source: html/94e6cf86-97ed-5111-2804-d35773206c5f.htm
---
# Autodesk.Revit.DB.Analysis.MEPNetworkIterator.#ctor Method

Creates an iterator to visit the connected segments on one side of the network.

## Syntax (C#)
```csharp
public MEPNetworkIterator(
	Document pADoc,
	MEPAnalyticalNode startNode,
	MEPAnalyticalSegment startSegment
)
```

## Parameters
- **pADoc** (`Autodesk.Revit.DB.Document`) - The document of the analytical network.
- **startNode** (`Autodesk.Revit.DB.Analysis.MEPAnalyticalNode`) - The starting analytical node. It must be one of two nodes of the starting segment.
- **startSegment** (`Autodesk.Revit.DB.Analysis.MEPAnalyticalSegment`) - The starting analytical segment to specify the traversing direction from the starting node.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

