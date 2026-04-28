---
kind: method
id: M:Autodesk.Revit.DB.NamingUtils.IsValidName(System.String)
source: html/68b151b1-b170-f351-914a-5aa09ecdb1af.htm
---
# Autodesk.Revit.DB.NamingUtils.IsValidName Method

Identifies if the input string is valid for use as an object name in Revit.

## Syntax (C#)
```csharp
public static bool IsValidName(
	string string
)
```

## Parameters
- **string** (`System.String`) - The name to validate.

## Returns
True if the name is valid for use as a name in Revit, false if it contains prohibited characters and is invalid.

## Remarks
This routine checks only for prohibited characters in the string.
 When setting the name for an object there are other specific considerations which are checked
 (for example, the same name cannot be used twice for different elements of the same type).
 This routine does not check those conditions.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

