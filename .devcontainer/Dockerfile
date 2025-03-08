FROM mcr.microsoft.com/devcontainers/dotnet:8.0

# Install SQL Server tools
RUN wget https://packages.microsoft.com/config/debian/12/packages-microsoft-prod.deb -O packages-microsoft-prod.deb \
    && dpkg -i packages-microsoft-prod.deb \
    && rm packages-microsoft-prod.deb \
    && apt-get update \
    && ACCEPT_EULA=Y apt-get install -y mssql-tools18 unixodbc-dev \
    && echo 'export PATH="$PATH:/opt/mssql-tools18/bin"' >> /home/vscode/.bashrc

# Expose ports for the application
EXPOSE 5000 5001

# Set the default shell to bash
SHELL ["/bin/bash", "-c"] 