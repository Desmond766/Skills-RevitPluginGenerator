---
kind: method
id: M:Autodesk.Revit.DB.ExternalResourceUtils.GetAllExternalResourceReferences(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ExternalResourceType)
source: html/fe34e7b3-4147-6dc2-8d4f-c2368f42f210.htm
---
# Autodesk.Revit.DB.ExternalResourceUtils.GetAllExternalResourceReferences Method

Gets the ids of all elements which refer to a specific type of external resource.

## Syntax (C#)
```csharp
public static ISet<ElementId> GetAllExternalResourceReferences(
	Document document,
	ExternalResourceType resourceType
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The Revit Document containing the external resource references.
- **resourceType** (`Autodesk.Revit.DB.ExternalResourceType`) - The type of external resource.

## Returns
The ids of all elements which refer to external resources of the specified type.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

