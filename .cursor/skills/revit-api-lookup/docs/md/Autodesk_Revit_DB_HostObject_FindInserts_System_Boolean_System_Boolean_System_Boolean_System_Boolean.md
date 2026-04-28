---
kind: method
id: M:Autodesk.Revit.DB.HostObject.FindInserts(System.Boolean,System.Boolean,System.Boolean,System.Boolean)
source: html/58990230-38cb-3af7-fd25-96ed3215a43d.htm
---
# Autodesk.Revit.DB.HostObject.FindInserts Method

Gets the ids of the instances inserted into this host object.

## Syntax (C#)
```csharp
public IList<ElementId> FindInserts(
	bool addRectOpenings,
	bool includeShadows,
	bool includeEmbeddedWalls,
	bool includeSharedEmbeddedInserts
)
```

## Parameters
- **addRectOpenings** (`System.Boolean`) - True if rectangular openings should be included in the return.
- **includeShadows** (`System.Boolean`) - True if shadows should be included in the return.
- **includeEmbeddedWalls** (`System.Boolean`) - True if embedded walls should be included in the return.
- **includeSharedEmbeddedInserts** (`System.Boolean`) - True if shared embedded inserts should be included in the return.

## Returns
All the insertable instances' ids.

