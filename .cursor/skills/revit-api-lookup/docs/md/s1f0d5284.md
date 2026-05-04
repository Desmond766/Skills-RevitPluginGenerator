---
kind: method
id: M:Autodesk.Revit.DB.NamingUtils.CompareNames(System.String,System.String)
source: html/f9c744d3-8210-1c2a-aa5d-0182035b0c5c.htm
---
# Autodesk.Revit.DB.NamingUtils.CompareNames Method

Compares two object name strings using Revit's comparison rules.

## Syntax (C#)
```csharp
public static int CompareNames(
	string nameA,
	string nameB
)
```

## Parameters
- **nameA** (`System.String`) - The first object name to compare.
- **nameB** (`System.String`) - The second object name to compare.

## Returns
An integer indicating the result of the lexical comparison between the two names.
 Less than zero if nameA comes before nameB in the ordering, zero if nameA and nameB are equivalent,
 and greater than zero if nameA is comes after nameB in the ordering.

## Remarks
This routine is similar to System.String.Compare(), but uses Revit rules for comparison. This involves
 breaking the names into alphabetic and numeric tokens and comparing tokens individually. Neither comparand is
 allowed to be Nothing nullptr a null reference ( Nothing in Visual Basic) . Note that this routine does consider case in comparing names. Some Revit element types disallow assignment
 of names where the only difference with existing names is the case of one or more characters, while other
 element types do not have this restriction. This routine does not take the particular element type into
 account, so it may not identify all "duplicates" if the names are to be used for some element types.
 Attempting to set the name on the target Element should provide the final indication of whether it is valid.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

