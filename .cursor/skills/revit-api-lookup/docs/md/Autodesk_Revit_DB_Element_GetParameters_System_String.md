---
kind: method
id: M:Autodesk.Revit.DB.Element.GetParameters(System.String)
zh: 构件、图元、元素
source: html/0cf342ef-c64f-b0b7-cbec-da8f3428a7dc.htm
---
# Autodesk.Revit.DB.Element.GetParameters Method

**中文**: 构件、图元、元素

Retrieves the parameters from the element via the given name.

## Syntax (C#)
```csharp
public IList<Parameter> GetParameters(
	string name
)
```

## Parameters
- **name** (`System.String`) - The name of the parameter to be retrieved.

## Returns
A collection containing the parameters having the same given parameter name.

## Remarks
Multiple matches of parameters with the same name can occur because shared parameters or project parameters can be bound to an element category even if there is a built-in parameter with the same name already. If this method is used to find built-in parameters the code will not be portable to other languages of Revit (because built-in parameter names are translated, and this method matches the translation). For the reasons above this method should be used sparingly and when portability across multiple languages is not a requirement. Safer approaches include: get_Parameter(Guid) to get a shared parameter by stored guid. get_Parameter(BuiltInParameter) to find a built-in parameter in a language-independent way.

