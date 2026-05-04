---
kind: method
id: M:Autodesk.Revit.DB.Element.RefersToExternalResourceReference(Autodesk.Revit.DB.ExternalResourceType)
zh: 构件、图元、元素
source: html/0a4aabb3-f684-0800-7bf5-31540831593f.htm
---
# Autodesk.Revit.DB.Element.RefersToExternalResourceReference Method

**中文**: 构件、图元、元素

Determines whether this Element uses external resources associated with
 a specified external resource type.

## Syntax (C#)
```csharp
public bool RefersToExternalResourceReference(
	ExternalResourceType resourceType
)
```

## Parameters
- **resourceType** (`Autodesk.Revit.DB.ExternalResourceType`) - The desired external resource type.

## Returns
Returns true if this Element uses external resources associated with
 the specified external resource type; otherwise, false.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

