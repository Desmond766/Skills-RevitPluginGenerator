---
kind: method
id: M:Autodesk.Revit.DB.Element.LookupParameter(System.String)
zh: 构件、图元、元素
source: html/4400b9f8-3787-0947-5113-2522ff5e5de2.htm
---
# Autodesk.Revit.DB.Element.LookupParameter Method

**中文**: 构件、图元、元素

Attempts to find a parameter on the element which has the given name.

## Syntax (C#)
```csharp
public Parameter LookupParameter(
	string name
)
```

## Parameters
- **name** (`System.String`) - The name of the parameter to be retrieved.

## Returns
The matching parameter. This return may be Nothing nullptr a null reference ( Nothing in Visual Basic) if there is no matching parameter. If there are multiple matching parameters the first one found is returned.

## Remarks
This method will attempt to find a parameter on this Element whose name matches the input. The possible results include:
 A single matching parameter is found: it will be returned. No matching parameter is found: Nothing nullptr a null reference ( Nothing in Visual Basic) is returned. Multiple matching parameters exist. In this situation the first one encountered will be returned. This match is determined at random and may change in the future. Multiple matches of parameters with the same name can occur because shared parameters or project parameters can be bound to an element category even if there is a built-in parameter with the same name already. If this method is used to find built-in parameters the code will not be portable to other languages of Revit (because built-in parameter names are translated, and this method matches the translation). For the reasons above this method should be used sparingly and only when you have a reasonable expectation that only one parameter exists with the given name, and when portability across multiple languages is not a requirement. Safer approaches include: GetParameters(String) to get all the matches with the given name. get_Parameter(Guid) to get a shared parameter by stored guid. get_Parameter(BuiltInParameter) to find a built-in parameter in a language-independent way.

