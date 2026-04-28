---
kind: method
id: M:Autodesk.Revit.DB.ParameterFilterElement.SetCategories(System.Collections.Generic.ICollection{Autodesk.Revit.DB.ElementId})
source: html/a124ea27-f102-fa18-aa6c-72038f89cc7a.htm
---
# Autodesk.Revit.DB.ParameterFilterElement.SetCategories Method

Sets the categories admitted by this filter.

## Syntax (C#)
```csharp
public void SetCategories(
	ICollection<ElementId> categories
)
```

## Parameters
- **categories** (`System.Collections.Generic.ICollection < ElementId >`)

## Remarks
Testing that an element's category is a member of this set is,
 essentially, the first rule of the filter. Changing the set of categories will clear any rules that use parameters
 that are not applicable for the new set of categories.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

