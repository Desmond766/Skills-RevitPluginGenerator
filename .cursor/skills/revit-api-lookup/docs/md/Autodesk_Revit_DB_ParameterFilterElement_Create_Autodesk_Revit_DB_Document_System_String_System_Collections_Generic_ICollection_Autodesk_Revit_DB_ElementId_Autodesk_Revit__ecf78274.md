---
kind: method
id: M:Autodesk.Revit.DB.ParameterFilterElement.Create(Autodesk.Revit.DB.Document,System.String,System.Collections.Generic.ICollection{Autodesk.Revit.DB.ElementId},Autodesk.Revit.DB.ElementFilter)
zh: 创建、新建、生成、建立、新增
source: html/5c88b083-2c49-b8be-07d3-017bfd73a051.htm
---
# Autodesk.Revit.DB.ParameterFilterElement.Create Method

**中文**: 创建、新建、生成、建立、新增

Creates a new ParameterFilterElement in the given document.

## Syntax (C#)
```csharp
public static ParameterFilterElement Create(
	Document aDocument,
	string name,
	ICollection<ElementId> categories,
	ElementFilter elementFilter
)
```

## Parameters
- **aDocument** (`Autodesk.Revit.DB.Document`) - The document in which to create the ParameterFilterElement.
- **name** (`System.String`) - The user-visible name for the new ParameterFilterElement.
- **categories** (`System.Collections.Generic.ICollection < ElementId >`) - The categories for the new ParameterFilterElement.
- **elementFilter** (`Autodesk.Revit.DB.ElementFilter`) - The rules for the new ParameterFilterElement, represented as an ElementFilter.
 ElementFilter is either an ElementParameterFilter or an ElementLogicalFilter
 representing a Boolean combination of ElementParameterFilters. In addition, we check that
 each ElementParameterFilter satisfies the following conditions:
 Its array of FilterRules is not empty and contains:
 Any number of FilterRules of type FilterValueRule, FilterInverseRule, and SharedParameterApplicableRule or Exactly one FilterCategoryRule containing only one category from categories stored by this ParameterFilterElement or Exactly two rules: the first one is a FilterCategoryRule containing only one category from categories stored by this ParameterFilterElement and
 the second one is a FilterRule of type FilterValueRule, FilterInverseRule, or SharedParameterApplicableRule. 
 Note that cases in the second and third bullet are currently allowed only if the parent node of ElementParameterFilter is LogicalOrFilter.

## Returns
A pointer to the new ParameterFilterElement.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - name is an empty string or contains only whitespace.
 -or-
 name cannot include prohibited characters, such as "{, }, [, ], |, ;, less-than sign, greater-than sign, ?, `, ~".
 -or-
 The given value for name is already in use as a filter element name.
 -or-
 One of the given rules refers to a parameter that does not apply to this filter's categories.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentsInconsistentException** - The ElementFilter is not acceptable for use by a ParameterFilterElement.

