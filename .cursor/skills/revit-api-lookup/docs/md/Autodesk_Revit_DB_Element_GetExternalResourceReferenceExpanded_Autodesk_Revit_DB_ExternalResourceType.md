---
kind: method
id: M:Autodesk.Revit.DB.Element.GetExternalResourceReferenceExpanded(Autodesk.Revit.DB.ExternalResourceType)
zh: 构件、图元、元素
source: html/1a28171e-8460-d849-4e7d-9a306a22cd6e.htm
---
# Autodesk.Revit.DB.Element.GetExternalResourceReferenceExpanded Method

**中文**: 构件、图元、元素

Gets the collection of ExternalResourceReference associated with a specified external resource type.

## Syntax (C#)
```csharp
public IList<ExternalResourceReference> GetExternalResourceReferenceExpanded(
	ExternalResourceType resourceType
)
```

## Parameters
- **resourceType** (`Autodesk.Revit.DB.ExternalResourceType`) - The desired external resource type.

## Returns
The collection of the ExternalResourceReference associated with a specified external resource type.

## Remarks
Use this API for an element which has multiple external resource references
 under a specified type, e.g., AppearanceAssetElement.
 See also: [!:Autodesk::Revit::DB::Element::getExternalResourceReference] .

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - This Element does not use a resource reference for the specified resource type.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

