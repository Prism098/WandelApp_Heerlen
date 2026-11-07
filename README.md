🤖 Monorepo for the: Casus Secur "Exotisch Nederland" voor de gemeente Heerlen.
Project Contribution Guidelines

This project enforces structured commit messages, code review policies, and branch naming conventions to maintain a clean and scalable codebase.
📌 Commit Guidelines (Conventional Commits)

All commits must follow the Conventional Commits specification. This ensures clear and structured commit history.
Commit Message Format:

<type>(<scope>): <short description>

[optional body]

[optional footer(s)]

[optional footer(s)]

Commit Types:

    feat: A new feature
    fix: A bug fix
    docs: Documentation changes
    style: Formatting changes (no logic changes)
    refactor: Code restructuring without changing behavior
    perf: Performance improvements
    test: Adding or updating tests
    chore: Maintenance tasks (e.g., CI/CD changes, dependencies)

Example:

Prism098/cyb-41-swc

feat(auth): add JWT authentication support

Copy button for branch names in linear:
Screenshot 2025-02-20 at 12 11 34
Pull Request & Review Policy
Pre-Main Branch Merges

    Requires at least 2 reviews before merging.

Staging Branch Merges

    Requires at least 1 reviewer before merging.

✅ Code Commenting Standards (Conventional Comments)

All comments should follow the Conventional Comments format for clarity and consistency.
Comment Format:

<type>: <message>

Types of Comments:

    TODO: TODO: Implement the API integration
    FIXME: FIXME: This needs error handling
    HACK: HACK: Temporary workaround for issue
    NOTE: NOTE: This function assumes a positive integer input
    OPTIMIZE: OPTIMIZE: Improve the efficiency of this loop

By following these conventions, we ensure better collaboration, maintainability, and traceability of our codebase. 🚀
