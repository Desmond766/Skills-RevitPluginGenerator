---
kind: method
id: M:Autodesk.Revit.DB.WorksetConfiguration.#ctor(Autodesk.Revit.DB.WorksetConfigurationOption)
source: html/a0dfffd6-e147-ce36-4cb6-32ce14c76ce2.htm
---
# Autodesk.Revit.DB.WorksetConfiguration.#ctor Method

Constructs a new workset configuration with an initial setting to open or close all user-created worksets, or to open last viewed worksets.

## Syntax (C#)
```csharp
public WorksetConfiguration(
	WorksetConfigurationOption option
)
```

## Parameters
- **option** (`Autodesk.Revit.DB.WorksetConfigurationOption`) - The option to open or close all user created worksets by default.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

