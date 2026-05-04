---
kind: method
id: M:Autodesk.Revit.DB.FailureDefinition.CreateFailureDefinition(Autodesk.Revit.DB.FailureDefinitionId,Autodesk.Revit.DB.FailureSeverity,System.String)
source: html/5c2aa975-9b44-f5b8-bf9b-519deeb015b4.htm
---
# Autodesk.Revit.DB.FailureDefinition.CreateFailureDefinition Method

Creates an instance of a FailureDefinition.

## Syntax (C#)
```csharp
public static FailureDefinition CreateFailureDefinition(
	FailureDefinitionId id,
	FailureSeverity severity,
	string messageString
)
```

## Parameters
- **id** (`Autodesk.Revit.DB.FailureDefinitionId`) - Unique identifier of the failure.
- **severity** (`Autodesk.Revit.DB.FailureSeverity`) - The severity of the failure. Cannot be FailureSeverity::None.
- **messageString** (`System.String`) - A user-visible string describing the failure.

## Returns
The created FailureDefinition instance.

## Remarks
The newly created FailureDefinition will be added to the FailureDefinitionRegistry. Because FailureDefinition
 could only be registered when Revit starting up, this function cannot be used after Revit has already started.
 Throws InvalidOperationException if invoked after Revit start-up is completed.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The id of failure definition is not valid.
 -or-
 The id of failure definition is already used to register another FailureDefinition.
 -or-
 The severity of failures cannot be FailureSeverity::None.
 -or-
 Message string is empty or contains invalid characters.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

