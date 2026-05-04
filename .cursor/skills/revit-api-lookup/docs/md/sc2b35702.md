---
kind: method
id: M:Autodesk.Revit.DB.Element.GetExternalResourceReference(Autodesk.Revit.DB.ExternalResourceType)
zh: 构件、图元、元素
source: html/fb4b9493-1d7b-5387-c171-2078225183ca.htm
---
# Autodesk.Revit.DB.Element.GetExternalResourceReference Method

**中文**: 构件、图元、元素

Gets the ExternalResourceReference associated with a specified external resource type.

## Syntax (C#)
```csharp
public ExternalResourceReference GetExternalResourceReference(
	ExternalResourceType resourceType
)
```

## Parameters
- **resourceType** (`Autodesk.Revit.DB.ExternalResourceType`) - The desired external resource type.

## Returns
The copy of the ExternalResourceReference associated with a specified external resource type.

## Remarks
For an element which has multiple external resource references
 under a specified type like AppearanceAssetElement, it will return the first one.
 See also: [!:Autodesk::Revit::DB::Element::getExternalResourceReferenceExpanded] .

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - This Element does not use a resource reference for the specified resource type.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

