---
kind: method
id: M:Autodesk.Revit.DB.Element.GetChangeTypeParameter(Autodesk.Revit.DB.Parameter)
zh: 构件、图元、元素
source: html/19ee7026-0e04-5bd2-b046-b14b59d4bc4e.htm
---
# Autodesk.Revit.DB.Element.GetChangeTypeParameter Method

**中文**: 构件、图元、元素

Returns ChangeType associated with a change in a parameter's value

## Syntax (C#)
```csharp
public static ChangeType GetChangeTypeParameter(
	Parameter param
)
```

## Parameters
- **param** (`Autodesk.Revit.DB.Parameter`) - Parameter for the ChangeType to trigger on

## Returns
ChangeType that can be used to define a trigger for an Updater,
 triggering on parameter value change

## Remarks
Use this change type to trigger an Updater when the value of an element's parameter changes. 
 Note: This change type will not trigger on newly created or deleted elements.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was Nothing nullptr a null reference ( Nothing in Visual Basic)

