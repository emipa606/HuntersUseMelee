# Copilot Instructions for Hunters Use Melee! (Continued) Mod

## Mod Overview and Purpose

**Hunters Use Melee! (Continued)** is an enhancement mod for RimWorld that extends the capabilities of your hunters, allowing them to use melee weapons and even their bare fists while hunting, in addition to ranged weapons. This mod stems from the original concept by LockdownX7, maintained by Keeper, and has been reimplemented to utilize Harmony for a cleaner and more efficient performance. The mod is lightweight and safe to add or remove from existing save games without causing lasting changes.

## Key Features and Systems

- **Melee Hunting:** Allows hunters to use melee weapons for hunting, catering to different playstyles and tactical decisions.
- **Fist-Based Hunting:** Supports hunting without weapons, useful in specific scenarios or for challenge runs.
- **Simple Sidearms Compatibility:** Compatible with the Simple Sidearms mod, allowing seamless weapon management for hunters.
- **Mod Settings Menu:** Offers settings configuration directly in the game, enhancing usability and flexibility.

## Coding Patterns and Conventions

- **C# Organization:** The project follows an organized structure with separate C# files for Harmony patches, mod initialization, settings, and main logic. Each file handles distinct functionalities for clarity and maintainability.
- **Naming Conventions:** Classes and methods use PascalCase, and private members use camelCase. This consistency ensures code readability.
- **Minimal Impact and Detours:** The mod applies minimal patches using Harmony to maintain compatibility and performance.

## XML Integration

The mod includes an `About.xml` file critical for defining mod metadata, dependencies, and compatibility information. Ensure this file correctly references important dependencies like **brrainz.harmony** to prevent any integration issues with existing mod setups.

## Harmony Patching

The mod leverages **Harmony 2.x** for runtime patching of RimWorld's base methods. This approach replaces the outdated detour method and involves:
- **Postfix and Prefix Methods:** Used to inject custom logic around RimWorld's existing behavior.
- **Centralized HarmonyPatches Class:** Manages all Harmony-related patches for easier maintenance and debugging.

## Suggestions for Copilot

To make the most of GitHub Copilot:

1. **Consistent Context:** Start writing clear and descriptive method signatures or comments before invoking Copilot for more accurate completions.
2. **Leverage Existing Code:** Use Copilot to autofill repetitive patterns or boilerplate, especially for Harmony patches and mod settings.
3. **Iterative Approaches:** Consider multiple completion suggestions, adapting Copilot's offerings to align with your desired functionality or optimization requirements.
4. **XML Assistance:** Copilot can help streamline XML edits by suggesting tags and attributes based on your partial inputs in `About.xml`.

Feel free to explore different coding styles and techniques offered by Copilot while maintaining the mod's overall consistency and performance efficiency.

---

With these guidelines, you are well-equipped to maintain and extend the **Hunters Use Melee!** mod collaboratively with Copilot, ensuring a streamlined development process and contributing to an innovative RimWorld modding community.

## Project Solution Guidelines
- Relevant mod XML files are included as Solution Items under the solution folder named XML, these can be read and modified from within the solution.
- Use these in-solution XML files as the primary files for reference and modification.
- The `.github/copilot-instructions.md` file is included in the solution under the `.github` solution folder, so it should be read/modified from within the solution instead of using paths outside the solution. Update this file once only, as it and the parent-path solution reference point to the same file in this workspace.
- When making functional changes in this mod, ensure the documented features stay in sync with implementation; use the in-solution `.github` copy as the primary file.
- In the solution is also a project called Assembly-CSharp, containing a read-only version of the decompiled game source, for reference and debugging purposes.
- For any new documentation, update this copilot-instructions.md file rather than creating separate documentation files.


## Hard rules (must follow)
- Do NOT run commands that modify the repo (no git commit, git apply, dotnet format) unless explicitly asked.
- Prefer minimal reads: read only the smallest code region needed (around the suspicious lines).
- When mentioning SonarQube issues, automatically use the SonarQube MCP service to fetch and address issues instead of making inferred fixes without querying SonarQube first.
- When mentioning the rimworld log, automatically use the Rimworld MCP service to fetch the log.

